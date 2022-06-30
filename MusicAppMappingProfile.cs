using AutoMapper;
using Music_App_Api.DTOs.User;
using Music_App_Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music_App_Api
{
    public class MusicAppMappingProfile : Profile
    {
        public MusicAppMappingProfile()
        {
            CreateMap<User, UserDTO>();
        }
    }
}
