using CrazyCatGang.Domain.DTO;
using CrazyCatGang.Domain.Interfaces;
using CrazyCatGang.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrazyCatGang.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetUsers")]
        public async Task<ActionResult<CrazyCatGangResponse<List<User>>>> GetUsers()
        {
            var users = await _userService.GetUsers();
            return Ok(users);
        }

        [HttpGet("GetUserById/{userID}")]
        public async Task<ActionResult<CrazyCatGangResponse<User>>> GetUserById(int userID)
        {
            var user = await _userService.GetUserById(userID);
            return Ok(user);
        }

        [HttpGet("GetUserAccount")]
        public async Task<ActionResult<CrazyCatGangResponse<User>>> GetUserByPassword(string userEmail, string userPassword)
        {
            var user = await _userService.GetUserAccount(userEmail, userPassword);
            return Ok(user);
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult<CrazyCatGangResponse<User>>> CreateUser(UserPostAndPutDTO user)
        {
            var createdUser = await _userService.CreateUser(user);
            return Ok(createdUser);
        }

        [HttpPut("UpdateUser/{userID}")]
        public async Task<ActionResult<CrazyCatGangResponse<User>>> UpdateUser(int userID, UserPostAndPutDTO user)
        {
            var updatedUser = await _userService.UpdateUser( userID, user);
            return Ok(updatedUser);
        }

        [HttpDelete("DeleteUser/{userID}")]
        public async Task<ActionResult<CrazyCatGangResponse<User>>> DeleteUser(int userID)
        {
            var deletedUser = await _userService.DeleteUser(userID);
            return Ok(deletedUser);
        }

    }
}
