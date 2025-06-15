using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Interfaces
{
    /// <summary>
    /// Репозиторий пользователей
    /// </summary>
    public interface IUserRepository
    {
        public IUser Get(int userId);
    }
}
