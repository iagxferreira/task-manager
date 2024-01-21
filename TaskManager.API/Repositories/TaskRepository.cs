using Microsoft.EntityFrameworkCore;
using TaskManager.API.Data;
using TaskManager.API.Models;
using TaskManager.API.Repositories.Abstract;
using TaskManager.API.Repositories.Interfaces;
using TaskDomain = TaskManager.Domain.Entities.Task;

namespace TaskManager.API.Repositories
{
    public class TaskRepository(TaskManagerDataContext context) : BaseRepository(context), ITaskRepository
    {
        public async Task<TaskModel> Create(TaskDomain task)
        {
            var model = new TaskModel() { Id = 0, Title = task.Title, DueDate = task.DueDate, Status = task.Status };
            this.context.Tasks.Add(model);
            await this.context.SaveChangesAsync();
            return model;
        }

        public async Task<TaskModel> Delete(int id)
        {
            var model = await context.Tasks.FirstOrDefaultAsync(item => item.Id == id);
            if (model == null) throw new Exception("Conteúdo não encontrado"); ;
            context.Tasks.Remove(model);
            await context.SaveChangesAsync();
            return model;
        }

        public async Task<List<TaskModel>> Read() => await context.Tasks.ToListAsync();

        public async Task<TaskModel?> ReadById(int id) => await context.Tasks.FirstOrDefaultAsync(item => item.Id == id);

        public async Task<TaskModel> Update(int id, TaskDomain task)
        {
            var model = await context.Tasks.FirstOrDefaultAsync(item => item.Id == id);
            if (model == null) throw new Exception("Conteúdo não encontrado");

            model.Title = task.Title;
            model.Status = task.Status;
            model.DueDate = task.DueDate;

            context.Tasks.Update(model);
            await context.SaveChangesAsync();
            return model;
        }
    }
}
