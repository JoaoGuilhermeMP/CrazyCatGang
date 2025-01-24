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

        [HttpGet("GetUserByPassword/{userPassword}")]
        public async Task<ActionResult<CrazyCatGangResponse<User>>> GetUserByPassword(string userPassword)
        {
            var user = await _userService.GetUserByPassword(userPassword);
            return Ok(user);
        }

    }
}
