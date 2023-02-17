using AutoMapper;
using UserManagement.Entities;
using UserManagement.Models;

namespace UserManagement.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() { 
            CreateMap<CreateUserDto, User>().ReverseMap();
            CreateMap<UserResponseDto, User>().ReverseMap();
        }
    }
}
