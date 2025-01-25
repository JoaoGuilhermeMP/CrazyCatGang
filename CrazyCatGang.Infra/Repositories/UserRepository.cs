using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyCatGang.Domain.DTO;
using CrazyCatGang.Domain.Interfaces;
using CrazyCatGang.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CrazyCatGang.Infra.Repositories
{


    public class UserRepository : IUserRepository
    {

        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }


        public async Task<User> GetUserAccount(string email, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(x =>  x.Email == email &&  x.Password == password  );
        }

        public async Task<UserPostAndPutDTO> CreateUser(UserPostAndPutDTO userDto)
        {
            var user = new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                CPF = userDto.CPF,
                Email = userDto.Email,
                Password = userDto.Password,
                Phone = userDto.Phone,
                Address = userDto.Address
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            
            return userDto;
        }

        public async Task<UserPostAndPutDTO> UpdateUser(int userID, UserPostAndPutDTO userDto)
        {

            var user = _context.Users.FirstOrDefault(x => x.Id == userID);

            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.CPF = userDto.CPF;
            user.Email = userDto.Email;
            user.Password = userDto.Password;
            user.Phone = userDto.Phone;
            user.Address = userDto.Address;
            

            _context.Users.Update(user);     
            await _context.SaveChangesAsync();


            return userDto;
        }

        public async Task<User> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}

