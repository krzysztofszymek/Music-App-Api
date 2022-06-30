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
        UserDTO GetUser();
        void UpdatePassword(UpdatePasswordDTO dto);
    }
}
