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
        void UpdateLogin();
        void RemoveUser();
        UserDTO GetUserById(int userId);
        List<UserDTO> GetAllUsers();
        void UpdatePassword(UpdatePasswordDTO dto);
    }
}
