using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Interfaces;

namespace Task2.Realisations
{
    public class UserRepository : IUserRepository
    {
        public IUser Get(int userId)
        {
            var Random = new Random();
            return new User(userId, userId, "test@gmail.com");
        }
    }
}
