using AutoMapper;
using TaskManager.API.Models;
using TaskManager.API.ViewModels;
using TaskManager.Domain.Entities;

namespace TaskManager.API.Helpers
{
    public class AutoMapperHelper : Profile
    {
        public AutoMapperHelper()
        {
            CreateMap<UserViewModel, User>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();
        }
    }
}
