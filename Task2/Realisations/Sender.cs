using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Interfaces;

namespace Task2.Realisations
{
    public class Sender1 : ISender
    {
        public Task<bool> Send(string message, string address)
        {
            return Task.Run(() =>
            {
                Thread.Sleep(500);
                return true;
            });
        }
    }

    public class Sender2 : ISender
    {
        public Task<bool> Send(string message, string address)
        {
            return Task.Run(() =>
            {
                Thread.Sleep(500);
                return true;
            });
        }
    }

    public class Sender3 : ISender
    {
        public Task<bool> Send(string message, string address)
        {
            return Task.Run(() =>
            {
                Thread.Sleep(500);
                return true;
            });
        }
    }

    public class Sender4 : ISender
    {
        public Task<bool> Send(string message, string address)
        {
            return Task.Run(() =>
            {
                Thread.Sleep(500);
                return true;
            });
        }
    }

    public class Sender5 : ISender
    {
        public Task<bool> Send(string message, string address)
        {
            return Task.Run(() =>
            {
                Thread.Sleep(500);
                return true;
            });
        }
    }
}
