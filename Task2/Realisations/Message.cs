using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Interfaces;

namespace Task2.Realisations
{

    public class Message : IMessage
    {

        public int UserId { get; }
        public string MessageText { get; }
        public Message(int userId, string messageText)
        {
            UserId = userId;
            MessageText = messageText;
        }
    }
}
