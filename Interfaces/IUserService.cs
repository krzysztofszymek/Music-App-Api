using Music_App_Api.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music_App_Api.Interfaces
{
    public interface IUserService
    {
        int CreateUser(CreateUserDTO dto);
        void RemoveUserById(int userId);
        UserDTO GetUserById(int userId);
        List<UserDTO> GetAllUsers();
        void UpdateLogin(int userId, string login);
        void UpdatePassword(int userId, UpdatePasswordDTO dto);
    }
}
