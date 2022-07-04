using Music_App_Api.DTOs.User;
using Music_App_Api.Models.DTOs.User;
using System.Collections.Generic;

namespace Music_App_Api.Interfaces
{
    public interface IUserService
    {
        int CreateUser(CreateUserDTO dto);
        void RemoveUserById(int userId);
        UserDTO GetUserById(int userId);
        List<UserDTO> GetAllUsers();
        UserDTO UpdateLogin(int userId, UpdateLoginDTO login);
        void UpdatePassword(int userId, UpdatePasswordDTO dto);
    }
}
