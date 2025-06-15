using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Interfaces
{
    /// <summary>
    /// Интерфейс, который реализуют все воркеры, отправляющие сообщения
    /// Существуют реализации ISender для отправки по 
    /// Телеграмм, СМС, e-mail, WhatsApp и тд и тп
    /// </summary>
    public interface ISender
    {
        /// <summary>
        /// Отправляет сообщение по указанному адресу, возвращает True в случае успешной доставки
        /// </summary>
        /// <param name="message"> текст сообщения </param>
        /// <param name="address"> адрес доставки, в зависимости от реализации может содержать 
        /// имя аккаунта, телефон, e-mail и тд и тп</param>
        /// <returns>Результат доставки, True, если сообщение успешно доставлено</returns>
        public Task<bool> Send(string message, string address);
    }
}
