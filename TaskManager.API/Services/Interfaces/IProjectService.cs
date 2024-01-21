using TaskManager.API.Models;

namespace TaskManager.API.Services.Interfaces
{
    public interface IProjectService
    {
        public Task<List<ProjectModel>> FindAll();
    }
}
