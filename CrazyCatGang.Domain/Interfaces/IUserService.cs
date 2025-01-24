using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyCatGang.Domain.Models;

namespace CrazyCatGang.Domain.Interfaces
{
    public interface IUserService
    {
        Task<CrazyCatGangResponse<List<User>>> GetUsers();
        
        Task<CrazyCatGangResponse<User>> GetUserById(int id);

        Task<CrazyCatGangResponse<User>> GetUserByPassword(string password);


    }
}
