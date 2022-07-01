using AutoMapper;
using Music_App_Api.DTOs.User;
using Music_App_Api.Entities;
using Music_App_Api.Exceptions;
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
            var users = _dbContext.Users;

            if (users == null)
                throw new NotFoundException("User list is empty");

            List<UserDTO> usersDTO = _mapper.Map<List<UserDTO>>(users);

            return usersDTO;
        }

        public UserDTO GetUserById(int userId)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == userId);

            if (user is null)
                throw new NotFoundException("User not found");

            var userDTO = _mapper.Map<UserDTO>(user);

            return userDTO;
        }

        public void RemoveUserById(int userId)
        {
            var user = _dbContext.Users.First(u => u.Id == userId);

            // Notfound Exception

            _dbContext.Remove(user);
            _dbContext.SaveChanges();
        }

        public void UpdateLogin(int userId, string newLogin)
        {
            var user = _dbContext.Users.First(u => u.Id == userId);

            if (newLogin != user.Login)
                user.Login = newLogin;
            else
                throw new Exception();

            _dbContext.SaveChanges();
        }

        public void UpdatePassword(int userId, UpdatePasswordDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
