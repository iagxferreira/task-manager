using TaskManager.API.Models;
using TaskManager.Domain.Entities;

namespace TaskManager.API.Repositories.Interfaces
{
    public interface IProjectRepository : ICompoundModelRepository<ProjectModel, Project, int, Guid>
    {
        public Task<ProjectModel> AddTask(int projectId, TaskModel task);
    }
}
