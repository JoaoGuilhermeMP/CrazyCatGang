using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyCatGang.Domain.DTO;
using CrazyCatGang.Domain.Models;

namespace CrazyCatGang.Domain.Interfaces
{
    public interface IUserService
    {
        Task<CrazyCatGangResponse<List<User>>> GetUsers();
        
        Task<CrazyCatGangResponse<User>> GetUserById(int id);

        Task<CrazyCatGangResponse<User>> GetUserAccount(string email, string password);

        Task<CrazyCatGangResponse<UserPostAndPutDTO>> CreateUser(UserPostAndPutDTO user);

        Task<CrazyCatGangResponse<UserPostAndPutDTO>> UpdateUser(int userID, UserPostAndPutDTO user);

        Task<CrazyCatGangResponse<User>> DeleteUser(int id);

    }
}
