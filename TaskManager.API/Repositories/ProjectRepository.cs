using Microsoft.EntityFrameworkCore;
using TaskManager.API.Data;
using TaskManager.API.Models;
using TaskManager.API.Repositories.Abstract;
using TaskManager.API.Repositories.Interfaces;
using TaskManager.Domain.Entities;

namespace TaskManager.API.Repositories
{
    public class ProjectRepository(TaskManagerDataContext context) : BaseRepository(context), IProjectRepository
    {
        public async Task<ProjectModel> Create(Project project)
        {
            var model = new ProjectModel() { Id = 0, };
            this.context.Projects.Add(model);
            await this.context.SaveChangesAsync();
            return model;
        }

        public async Task<ProjectModel> Delete(int id)
        {
            var model = await context.Projects.FirstOrDefaultAsync(item => item.Id == id);
            if (model == null) throw new Exception("Conteúdo não encontrado"); ;
            context.Projects.Remove(model);
            await context.SaveChangesAsync();
            return model;
        }

        public async Task<List<ProjectModel>> Read() => await context.Projects.ToListAsync();
        public async Task<ProjectModel?> ReadById(int id) => await context.Projects.FirstOrDefaultAsync(item => item.Id == id);

        public Task<ProjectModel> Update(int id, Project domain)
        {
            throw new NotImplementedException();
        }
    }
}
