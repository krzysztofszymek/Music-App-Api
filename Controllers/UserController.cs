using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Music_App_Api.Interfaces;
using Music_App_Api.DTOs.User;
using Music_App_Api.Models.DTOs.User;

namespace Music_App_Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public ActionResult CreateUser([FromBody] CreateUserDTO dto)
        {
            var userId = _userService.CreateUser(dto);
            return Created($"/api/user/{userId}", null);
        }

        [HttpGet]
        public ActionResult<List<UserDTO>> GetAllUsers()
        {
            List<UserDTO> users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{userId}")]
        public ActionResult<UserDTO> GetUserbyId([FromRoute] int userId)
        {
            UserDTO user = _userService.GetUserById(userId);
            return Ok(user);
        }

        [HttpDelete("{userId}")]
        public ActionResult RemoveUser([FromRoute] int userId)
        {
            _userService.RemoveUserById(userId);
            return Ok();
        }

        [HttpPut("{userId}/login")]
        public ActionResult<UserDTO> UpdateUserLogin([FromRoute] int userId, [FromBody] UpdateLoginDTO dto)
        {
            UserDTO user = _userService.UpdateLogin(userId, dto);
            return Ok(user);
        }

        [HttpPut("{userId}/password")]
        public ActionResult ChangeUserPassword([FromRoute] int userId, [FromBody] UpdatePasswordDTO dto)
        {
            _userService.UpdatePassword(userId, dto);
            return Ok("Password changed");
        }
    }
}
