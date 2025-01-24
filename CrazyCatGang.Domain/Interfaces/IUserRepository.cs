using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyCatGang.Domain.Models;

namespace CrazyCatGang.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();

        Task<User> GetUserById(int id);

        Task<User> GetUserByPassword(string password);
    }
}
