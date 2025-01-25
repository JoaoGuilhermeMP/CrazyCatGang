using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyCatGang.Domain.DTO;
using CrazyCatGang.Domain.Interfaces;
using CrazyCatGang.Domain.Models;

namespace CrazyCatGang.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<CrazyCatGangResponse<User>> GetUserById(int id)
        {
            CrazyCatGangResponse<User> response = new CrazyCatGangResponse<User>();

            try
            {
               var user = await _userRepository.GetUserById(id);

                if(user == null)
                {
                    response.Mensagem = "User is Null";
                    response.status = false;
                    response.StatusCode = 404;
                    return response;
                }

                response.Data = user;

                response.Mensagem = "User found";

                response.status = true;

                response.StatusCode = 200;

                return response;

            }
            catch
            {
                response.Mensagem = "Error to get User By ID";

                response.status = false;

                response.StatusCode = 500;

                return response;
            }

        }

        public async Task<CrazyCatGangResponse<List<Domain.Models.User>>> GetUsers()
        {
            CrazyCatGangResponse<List<User>> response = new CrazyCatGangResponse<List<User>>();

            try { 
                
                var users = await _userRepository.GetUsers();

                if (users == null)
                {
                    response.Mensagem = "User is Null";
                    response.status = false;
                    response.StatusCode = 404;
                    return response;
                }

                response.Data = users;

                response.Mensagem = "Users found";

                response.status = true;
                
                response.StatusCode = 200;

                return response;

            }
            catch
            {
                response.Mensagem = "Error to get Users";

                response.status = false; 

                response.StatusCode = 500;

                return response;
            }

        }

        public async Task<CrazyCatGangResponse<User>> GetUserAccount(string email, string password)
        {
            CrazyCatGangResponse<User> response = new CrazyCatGangResponse<User>();

            try
            {
                var user = await _userRepository.GetUserAccount(email, password);

                if (user == null)
                {
                    response.Mensagem = "User is Null";
                    response.status = false;
                    response.StatusCode = 404;
                    return response;
                }

                response.Data = user;
                response.Mensagem = "User found";
                response.status = true;
                response.StatusCode = 200;

                return response;

            }
            catch
            {
                response.Mensagem = "Error to get User By Password";
                response.status = false;
                response.StatusCode = 500;
                return response;

            }
        }

        public async Task<CrazyCatGangResponse<UserPostAndPutDTO>> CreateUser(UserPostAndPutDTO user)
        {
            CrazyCatGangResponse<UserPostAndPutDTO> response = new CrazyCatGangResponse<UserPostAndPutDTO>();

            try
            {
                var userCreated = await _userRepository.CreateUser(user);

                if (userCreated == null)
                {
                    response.Mensagem = "User is Null";
                    response.status = false;
                    response.StatusCode = 404;
                    return response;
                }

                response.Data = user;
                response.Mensagem = "User Created";
                response.status = true;
                response.StatusCode = 200;

                return response;

            }
            catch
            {
                response.Mensagem = "Error to Create User";
                response.status = false;
                response.StatusCode = 500;
                return response;
            }
        }

        public async Task<CrazyCatGangResponse<UserPostAndPutDTO>> UpdateUser(int userID, UserPostAndPutDTO user)
        {
            CrazyCatGangResponse<UserPostAndPutDTO> response = new CrazyCatGangResponse<UserPostAndPutDTO>();

            try
            {
                var userEdited = await _userRepository.UpdateUser(userID, user);

                if (userEdited == null)
                {
                    response.Mensagem = "User is Null";
                    response.status = false;
                    response.StatusCode = 404;
                    return response;
                }

                response.Data = user;
                response.Mensagem = "User Edited";
                response.status = true;
                response.StatusCode = 200;

                return response;

            }
            catch
            {
                response.Mensagem = "Error to Edit User";
                response.status = false;
                response.StatusCode = 500;
                return response;
            }
        }

        public async Task<CrazyCatGangResponse<User>> DeleteUser(int id)
        {
            CrazyCatGangResponse<User> response = new CrazyCatGangResponse<User>();

            try
            {
                var user = await _userRepository.DeleteUser(id);

                if (user == null)
                {
                    response.Mensagem = "User is Null";
                    response.status = false;
                    response.StatusCode = 404;
                    return response;
                }

                response.Data = user;

                response.Mensagem = "User Deleted";

                response.status = true;

                response.StatusCode = 200;

                return response;

            }
            catch
            {
                response.Mensagem = "Error to Delete User";

                response.status = false;

                response.StatusCode = 500;

                return response;
            }
        }
    }
}
