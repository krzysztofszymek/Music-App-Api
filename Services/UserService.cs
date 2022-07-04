using AutoMapper;
using Music_App_Api.DTOs.User;
using Music_App_Api.Entities;
using Music_App_Api.Exceptions;
using Music_App_Api.Interfaces;
using Music_App_Api.Models.DTOs.User;
using System.Collections.Generic;
using System.Linq;

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
            var user = GetUser(userId);

            var userDTO = _mapper.Map<UserDTO>(user);

            return userDTO;
        }

        public void RemoveUserById(int userId)
        {
            var user = GetUser(userId);

            _dbContext.Remove(user);
            _dbContext.SaveChanges();
        }

        public UserDTO UpdateLogin(int userId, UpdateLoginDTO dto)
        {
            var user = GetUser(userId);

            if (user.Login == dto.Login)
                throw new AlreadyExistsException("New login has to be different from current Login");

            user.Login = dto.Login;

            _dbContext.SaveChanges();

            var userDTO = _mapper.Map<UserDTO>(user);

            return userDTO;
        }

        public void UpdatePassword(int userId, UpdatePasswordDTO dto)
        {
            var user = GetUser(userId);

            if (dto.NewPassword != dto.ConfirmNewPassword)
                throw new AlreadyExistsException("New password and it's confirmation has to be the same");

            if (dto.NewPassword == user.Password)
                throw new AlreadyExistsException("The new password has to be different than the last.");
            
            user.Password = dto.NewPassword;

            _dbContext.SaveChanges();
        }

        public User GetUser(int userId)
        {
            var user = _dbContext.Users.First(u => u.Id == userId);

            if (user is null)
                throw new NotFoundException("User not found.");

            return user;
        }
    }
}
