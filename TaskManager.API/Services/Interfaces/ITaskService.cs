using TaskManager.API.Models;

namespace TaskManager.API.Services.Interfaces
{
    public interface ITaskService
    {
        public Task<List<TaskModel>> FindAll();

    }
}
