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
            var newUser = _mapper.Map<User>(dto);

            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();

            return newUser.Id;
        }

        public List<UserDTO> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public UserDTO GetUserById(int userId)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == userId);

            // Add Notfound exception

            var userDTO = _mapper.Map<UserDTO>(user);

            return userDTO;
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
