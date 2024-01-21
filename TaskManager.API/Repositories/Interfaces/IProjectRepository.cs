using TaskManager.API.Models;
using TaskManager.Domain.Entities;

namespace TaskManager.API.Repositories.Interfaces
{
    public interface IProjectRepository : IBaseRepository<ProjectModel, Project, int> { }
}
