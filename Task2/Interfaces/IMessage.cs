using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Interfaces
{
    /// <summary>
    /// Сообщение для доставки пользователю
    /// </summary>
    public interface IMessage
    {
        /// <summary>
        /// Идентификатор пользователя, которому надо доставить сообщение
        /// </summary>
        public int UserId { get; }
        /// <summary>
        /// Текст сообщения
        /// </summary>
        public string MessageText { get; }
    }
}
