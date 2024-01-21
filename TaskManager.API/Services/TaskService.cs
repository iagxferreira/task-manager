using AutoMapper;
using TaskManager.API.Models;
using TaskManager.API.Repositories.Interfaces;
using TaskManager.API.Services.Interfaces;

namespace TaskManager.API.Services
{
    public class TaskService(ITaskRepository repository, IMapper mapper) : ITaskService
    {
        private readonly ITaskRepository repository = repository;
        private readonly IMapper mapper = mapper;

        public async Task<List<TaskModel>> FindAll()
        {
            return await repository.Read();
        }
    }
}
