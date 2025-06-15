using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task2.Interfaces;
using Task2.Realisations;

namespace Task2
{
    public class Postman
    {
        /// <summary>
        /// Список, куда следует поместить все сообщения, которые не удалось доставить
        /// </summary>
        private readonly IUserRepository _userRepository;
        private readonly Dictionary<int, ISender> _senders;
        private readonly int _maxTotalThreads;
        private readonly int _maxThreadsPerSender;
        private readonly ConcurrentBag<IMessage> _failedMessages = new ConcurrentBag<IMessage>();

        public Postman(IUserRepository userRepository, Dictionary<int, ISender> senders,
                      int maxTotalThreads = 10, int maxThreadsPerSender = 3)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _senders = senders ?? throw new ArgumentNullException(nameof(senders));
            _maxTotalThreads = maxTotalThreads;
            _maxThreadsPerSender = maxThreadsPerSender;
        }

        /// <summary>
        /// Отправляет сообщения из списка messages пользователям
        /// Сообщение отправляется методом, указанным в записи пользователя
        /// по адресу, указанным в записи пользователя
        /// В случае, если сообщение не удалось доставить, помещает его в  FailedMessages
        /// </summary>
        /// <param name="messages"> коллекция сообщений </param>
        public async Task SendAsync(IEnumerable<IMessage> messages)
        {
            // Создаём семафоры для общего кол-ва и для методов доставки
            var semaphore = new SemaphoreSlim(_maxTotalThreads);
            var senderSemaphores = _senders.ToDictionary(
                x => x.Key,
                y => new SemaphoreSlim(_maxThreadsPerSender)
            );

            var tasks = new List<Task>();


            foreach (var message in messages)
            {
                tasks.Add(ProcessMessageAsync(message, semaphore, senderSemaphores));
            }



            // Дожидаемся выполнения всех Task
            await Task.WhenAll(tasks);

            //Уничтожаем семафоры, предварительно проверяем что они свободны
            Console.WriteLine($"semaphore {semaphore.CurrentCount - _maxTotalThreads}");
            semaphore.Dispose();
            foreach (var senderSemaphore in senderSemaphores.Values)
            {
                Console.WriteLine($"senderSemaphore {senderSemaphore.CurrentCount - _maxThreadsPerSender}");
                senderSemaphore.Dispose();
            }
        }

        private async Task ProcessMessageAsync(
        IMessage message,
        SemaphoreSlim semaphore,
        Dictionary<int, SemaphoreSlim> senderSemaphores)
        {
            // Учитывая что userRepository может быть удалённым, стоило сначала выгрузить в кэш? Не знаю.
            var user = _userRepository.Get(message.UserId); 
            if (user != null && _senders.TryGetValue(user.DeliveryMethod, out var sender))
            {
                await senderSemaphores[user.DeliveryMethod].WaitAsync();
                try
                {
                    await semaphore.WaitAsync();
                    try
                    {
                        bool success = await sender.Send(message.MessageText, user.Address);
                        if (!success)
                        {
                            Console.WriteLine($"failed {message.UserId} {message.MessageText}");
                            _failedMessages.Add(message);
                        }
                        else
                        {
                            Console.WriteLine($"finished {message.UserId} {message.MessageText}");
                        }
                    }
                    catch
                    {
                        _failedMessages.Add(message);
                    }
                    finally
                    {
                        semaphore.Release();
                    }
                }
                finally
                {
                    senderSemaphores[user.DeliveryMethod].Release();
                }
            }
            else 
            {
                _failedMessages.Add(message);
                return;
            }

        }
    }

}
