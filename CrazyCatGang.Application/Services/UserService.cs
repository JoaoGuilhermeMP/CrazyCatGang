using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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

        public async Task<CrazyCatGangResponse<List<User>>> GetUsers()
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

                var userValidated = validationUser(user);

                if (userValidated == false)
                {
                    response.Mensagem = "User is missing something. Verify your informations";
                    response.status = false;
                    response.StatusCode = 404;
                    return response;
                }

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

                var userValidated = validationUser(user);

                if (userValidated == false)
                {
                    response.Mensagem = "User is missing something. Verify your informations";
                    response.status = false;
                    response.StatusCode = 404;
                    return response;
                }

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

        private bool validationUser(UserPostAndPutDTO user)
        {
            var validationUserNames = validateUserNames(user);

            if (validationUserNames == false)
            {
                return false;
            }

            var validationUserCPF = validateUserCPF(user);

            if (validationUserCPF == false)
            {
                return false;
            }

            var validationUserEmail = validateUserEmail(user);

            if (validationUserEmail == false)
            {
                return false;
            }

            var validationUserPassword = validateUserPassword(user);

            if (validationUserPassword == false)
            {
                return false;
            }

            var validationUserPhone = validateUserPhone(user);

            if (validationUserPhone == false)
            {
                return false;
            }

            var validationUserAddress = validateUserAddress(user);

            if (validationUserAddress == false)
            {
                return false;
            }

            return true;
        }

        private bool validateUserNames(UserPostAndPutDTO user)
        {

            if (string.IsNullOrEmpty(user.FirstName ))
            {
                return false;
            }

            if (string.IsNullOrEmpty(user.LastName))
            {
                return false;
            }

            if (user.FirstName.Length < 1)
            {
                return false;
            }

            if (user.LastName.Length < 1)
            {
                return false;
            }

            return true;
        }

        private bool validateUserCPF(UserPostAndPutDTO user)
        {

            if (string.IsNullOrEmpty(user.CPF))
            {
                return false;
            }

            if (user.CPF.Length < 11 || user.CPF.Length > 15)
            {
                return false;
            }


            return true;
        }

        private bool validateUserEmail(UserPostAndPutDTO user)
        {
            if (string.IsNullOrEmpty(user.Email))
            {
                return false;
            }
            if (user.Email.Length < 6)
            {
                return false;
            }
            return true;
        }

        private bool validateUserPassword(UserPostAndPutDTO user)
        {
            if (string.IsNullOrEmpty(user.Password))
            {
                return false;
            }
            if (user.Password.Length < 8)
            {
                return false;
            }

            return true;
        }

        private bool validateUserPhone(UserPostAndPutDTO user)
        {
            if (string.IsNullOrEmpty(user.Phone))
            {
                return false;
            }
            if (user.Phone.Length < 8 || user.Phone.Length > 20)
            {
                return false;
            }
            return true;
        }

        private bool validateUserAddress(UserPostAndPutDTO user)
        {
            if (string.IsNullOrEmpty(user.Address))
            {
                return false;
            }
            if (user.Address.Length < 10)
            {
                return false;
            }
            return true;
        }
    }
}
