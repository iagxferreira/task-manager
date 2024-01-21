using TaskManager.API.Models;
using TaskManager.Domain.Entities;
using Task = TaskManager.Domain.Entities.Task;

namespace TaskManager.API.Services.Interfaces
{
    public interface ITaskService
    {
        public Task<List<TaskModel>> FindAll();
        public Task<ProjectModel> Create(Task task, int projectId);
    }
}
