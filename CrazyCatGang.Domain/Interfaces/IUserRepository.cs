using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyCatGang.Domain.DTO;
using CrazyCatGang.Domain.Models;

namespace CrazyCatGang.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();

        Task<User> GetUserById(int id);

        Task<User> GetUserAccount(string email, string password);

        Task<UserPostAndPutDTO> CreateUser(UserPostAndPutDTO user);

        Task<UserPostAndPutDTO> UpdateUser(int userID, UserPostAndPutDTO user);

        Task<User> DeleteUser(int id);

    }
}
