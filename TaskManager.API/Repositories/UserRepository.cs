using Microsoft.EntityFrameworkCore;
using TaskManager.API.Data;
using TaskManager.API.Models;
using TaskManager.API.Repositories.Interfaces;
using TaskManager.Domain.Entities;

namespace TaskManager.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskManagerDataContext _context;
        public UserRepository(TaskManagerDataContext context)
        {
            this._context = context;
        }

        public async Task<UserModel> Create(User user)
        {
            var model = new UserModel()
            {
                Id = Guid.NewGuid(),
                Email = user.Email,
                Name = user.Name
            };
            this._context.Users.Add(model);
            await this._context.SaveChangesAsync();
            return model;
        }

        public Task<UserModel> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserModel>> Read()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public Task<UserModel> ReadById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> Update(Guid id, User user)
        {
            throw new NotImplementedException();
        }
    }
}
