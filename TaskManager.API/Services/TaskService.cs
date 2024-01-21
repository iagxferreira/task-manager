using AutoMapper;
using TaskManager.API.Models;
using TaskManager.API.Repositories.Interfaces;
using TaskManager.API.Services.Interfaces;
using TaskManager.Domain.Entities;
using Task = TaskManager.Domain.Entities.Task;

namespace TaskManager.API.Services
{
    public class TaskService(ITaskRepository repository, IProjectRepository projectRepository, IMapper mapper) : ITaskService
    {
        private readonly ITaskRepository repository = repository;
        private readonly IProjectRepository projectRepository = projectRepository;
        private readonly IMapper mapper = mapper;

        public async Task<List<TaskModel>> FindAll()
        {
            return await repository.Read();
        }

        public async Task<ProjectModel> Create(Task task, int projectId)
        {
            return await projectRepository.AddTask(projectId, new TaskModel() { Title = task.Title, DueDate = task.DueDate, Status = task.Status, });
        }
    }
}
