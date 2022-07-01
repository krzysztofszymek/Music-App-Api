﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Music_App_Api.Interfaces;
using Music_App_Api.DTOs.User;

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

        [HttpGet("{userId}")]
        public ActionResult<UserDTO> GetUserbyId([FromRoute] int userId) 
        {
            UserDTO user = _userService.GetUserById(userId);
            return Ok(user);
        }

        [HttpGet]
        public ActionResult<List<UserDTO>> GetAllUsers()
        {
            List<UserDTO> users = _userService.GetAllUsers();
            return Ok(users);
        }
    }
}
