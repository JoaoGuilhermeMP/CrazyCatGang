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

            if (users.StatusCode == 200)
            {
                return Ok(users);
            }
            else if (users.StatusCode == 404)
            {
                return NotFound(users);
            }
            else if (users.StatusCode == 500)
            {
                return StatusCode(500, users);
            }

            return BadRequest(users);

        }

        [HttpGet("GetUserById/{userID}")]
        public async Task<ActionResult<CrazyCatGangResponse<User>>> GetUserById(int userID)
        {
            var user = await _userService.GetUserById(userID);

            if (user.StatusCode == 200)
            {
                return Ok(user);
            }
            else if (user.StatusCode == 404)
            {
                return NotFound(user);
            }
            else if (user.StatusCode == 500)
            {
                return StatusCode(500, user);
            }

            return BadRequest(user);

        }

        [HttpGet("GetUserAccount")]
        public async Task<ActionResult<CrazyCatGangResponse<User>>> GetUserByPassword(string userEmail, string userPassword)
        {
            var user = await _userService.GetUserAccount(userEmail, userPassword);

            if (user.StatusCode == 200)
            {
                return Ok(user);
            }
            else if (user.StatusCode == 404)
            {
                return NotFound(user);
            }
            else if (user.StatusCode == 500)
            {
                return StatusCode(500, user);
            }

            return BadRequest(user);

        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult<CrazyCatGangResponse<User>>> CreateUser(UserPostAndPutDTO user)
        {
            var createdUser = await _userService.CreateUser(user);

            if (createdUser.StatusCode == 200)
            {
                return Ok(createdUser);
            }
            else if (createdUser.StatusCode == 404)
            {
                return NotFound(createdUser);
            }
            else if (createdUser.StatusCode == 500)
            {
                return StatusCode(500, createdUser);
            }

            return BadRequest(createdUser);
        }

        [HttpPut("UpdateUser/{userID}")]
        public async Task<ActionResult<CrazyCatGangResponse<User>>> UpdateUser(int userID, UserPostAndPutDTO user)
        {
            var updatedUser = await _userService.UpdateUser(userID, user);

            if (updatedUser.StatusCode == 200)
            {
                return Ok(updatedUser);
            }
            else if (updatedUser.StatusCode == 404)
            {
                return NotFound(updatedUser);
            }
            else if (updatedUser.StatusCode == 500)
            {
                return StatusCode(500, updatedUser);
            }

            return BadRequest(updatedUser);
        }

        [HttpDelete("DeleteUser/{userID}")]
        public async Task<ActionResult<CrazyCatGangResponse<User>>> DeleteUser(int userID)
        {
            var deletedUser = await _userService.DeleteUser(userID);

            if (deletedUser.StatusCode == 200)
            {
                return Ok(deletedUser);
            }
            else if (deletedUser.StatusCode == 404)
            {
                return NotFound(deletedUser);
            }
            else if (deletedUser.StatusCode == 500)
            {
                return StatusCode(500, deletedUser);
            }

            return BadRequest(deletedUser);
        }

    }
}
