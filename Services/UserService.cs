using AutoMapper;
using Music_App_Api.DTOs.User;
using Music_App_Api.Entities;
using Music_App_Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music_App_Api.Services
{
    public class UserService : IUserService
    {
        private MusicAppDBContext _dbContext;
        private IMapper _mapper;

        public UserService(MusicAppDBContext dBContext, IMapper mapper)
        {
            _dbContext = dBContext;
            _mapper = mapper;
        }

        public int CreateUser(CreateUserDTO dto)
        {
            if (_dbContext.Users.Any(u => u.Email == dto.Email))
                throw new Exception("User with this Email already exists");

            if (_dbContext.Users.Any(u => u.Login == dto.Login))
                throw new Exception("User with this Login already exists");

            var newUser = _mapper.Map<User>(dto);

            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();

            return newUser.Id;
        }

        public UserDTO GetUser()
        {
            throw new NotImplementedException();
        }

        public void RemoveUser()
        {
            throw new NotImplementedException();
        }

        public void UpdateLogin()
        {
            throw new NotImplementedException();
        }

        public void UpdatePassword(UpdatePasswordDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
