using AutoMapper;
using Microsoft.ILP.UserService.DTOs;
using Microsoft.ILP.UserService.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Microsoft.ILP.UserService.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>();
        }
    }
}
