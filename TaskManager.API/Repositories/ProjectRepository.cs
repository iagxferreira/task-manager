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
        public async Task<ProjectModel> Create(Project project, Guid userId)
        {
            var model = new ProjectModel() { Id = 0, Name = project.Name, UserId = userId };
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

        public async Task<List<ProjectModel>> Read() => await context.Projects
            .ToListAsync();

        public async Task<ProjectModel?> ReadById(int id) => await context.Projects
                .FirstOrDefaultAsync(u => u.Id == id);

        public Task<ProjectModel> Update(int id, Project domain)
        {
            throw new NotImplementedException();
        }

        public async Task<ProjectModel> AddTask(int id, TaskModel task)
        {
            var project = await this.context.Projects.Include(item => item.Tasks).FirstOrDefaultAsync(item => item.Id == id);
            if (project == null) throw new Exception("Projeto não encontrado");
            task.ProjectId = project.Id;
            project.Tasks.Add(task);
            await this.context.SaveChangesAsync();
            return project;
        }
    }
}
