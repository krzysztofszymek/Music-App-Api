using Music_App_Api.DTOs.User;
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

        public UserService(MusicAppDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public int CreateUser(CreateUserDTO dto)
        {
            throw new NotImplementedException();
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
