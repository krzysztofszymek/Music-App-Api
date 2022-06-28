using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music_App_Api.Interfaces
{
    public interface IUserService
    {
        int CreateUser();
        void UpdateUser();
        void RemoveUser();
        void GetUser();
        void UpdatePassword();
    }
}
