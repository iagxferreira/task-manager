using Microsoft.EntityFrameworkCore;
using TaskManager.API.Data;
using TaskManager.API.Models;
using TaskManager.API.Repositories.Abstract;
using TaskManager.API.Repositories.Interfaces;
using TaskManager.Domain.Entities;

namespace TaskManager.API.Repositories
{
    public class UserRepository(TaskManagerDataContext context) : BaseRepository(context), IUserRepository
    {
        public async Task<UserModel> Create(User domain)
        {
            var model = new UserModel() { Id = Guid.NewGuid(), Email = domain.Email, Name = domain.Name };
            this.context.Users.Add(model);
            await this.context.SaveChangesAsync();
            return model;
        }

        public async Task<UserModel> Delete(Guid id)
        {
            var model = await context.Users.FirstOrDefaultAsync(item => item.Id == id);
            if (model == null) throw new Exception("Conteúdo não encontrado"); ;
            context.Users.Remove(model);
            await context.SaveChangesAsync();
            return model;
        }

        public async Task<List<UserModel>> Read() => await context.Users.ToListAsync();

        public async Task<UserModel?> ReadById(Guid id) => await context.Users.FirstOrDefaultAsync(item => item.Id == id);

        public async Task<UserModel> Update(Guid id, User domain)
        {
            var model = await context.Users.FirstOrDefaultAsync(item => item.Id == id);
            if (model == null) throw new Exception("Conteúdo não encontrado");

            model.Name = domain.Name;
            model.Email = domain.Email;

            context.Users.Update(model);
            await context.SaveChangesAsync();
            return model;
        }
    }
}
