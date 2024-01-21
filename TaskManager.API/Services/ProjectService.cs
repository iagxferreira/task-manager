using AutoMapper;
using TaskManager.API.Models;
using TaskManager.API.Repositories.Interfaces;
using TaskManager.API.Services.Interfaces;
using TaskManager.Domain.Entities;

namespace TaskManager.API.Services
{
    public class ProjectService(IProjectRepository repository, IMapper mapper) : IProjectService
    {
        private readonly IProjectRepository repository = repository;
        private readonly IMapper mapper = mapper;

        public async Task<ProjectModel> Create(Project project, Guid userId)
        {
            return await repository.Create(project, userId);
        }

        public async Task<List<ProjectModel>> FindAll()
        {
            return await repository.Read();
        }

        public async Task<ProjectModel?> FindById(int id)
        {
            return await repository.ReadById(id);
        }
    }
}
