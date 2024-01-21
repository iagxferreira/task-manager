using TaskManager.API.Models;
using TaskManager.Domain.Entities;

namespace TaskManager.API.Services.Interfaces
{
    public interface IProjectService
    {
        public Task<List<ProjectModel>> FindAll();
        public Task<ProjectModel?> FindById(int id);
        public Task<ProjectModel> Create(Project project, Guid userId);
    }
}
