using AutoMapper;
using TaskManager.API.Models;
using TaskManager.API.Repositories.Interfaces;
using TaskManager.API.Services.Interfaces;

namespace TaskManager.API.Services
{
    public class ProjectService(IProjectRepository repository, IMapper mapper) : IProjectService
    {
        private readonly IProjectRepository repository = repository;
        private readonly IMapper mapper = mapper;

        public async Task<List<ProjectModel>> FindAll()
        {
            return await repository.Read();
        }
    }
}
