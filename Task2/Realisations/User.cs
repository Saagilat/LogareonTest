using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Interfaces;

namespace Task2.Realisations
{
    public class User : IUser
    {
        public int Id { get; }
        public int DeliveryMethod { get; }
        public string Address { get; }
        
        public User(int id, int method, string address) {
            this.Id = id;
            this.DeliveryMethod = method;
            this.Address = address;
        }
    }
}
