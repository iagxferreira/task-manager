using AutoMapper;
using TaskManager.API.Models;
using TaskManager.API.ViewModels;
using TaskManager.Domain.Entities;
using Task = TaskManager.Domain.Entities.Task;

namespace TaskManager.API.Helpers
{
    public class AutoMapperHelper : Profile
    {
        public AutoMapperHelper()
        {
            CreateMap<UserViewModel, User>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<ProjectViewModel, Project>().ReverseMap();
            CreateMap<Project, ProjectModel>().ReverseMap();
            CreateMap<TaskViewModel, Task>().ReverseMap();
            CreateMap<Task, TaskModel>().ReverseMap();

        }
    }
}
