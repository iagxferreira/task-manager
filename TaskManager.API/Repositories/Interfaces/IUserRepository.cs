using TaskManager.API.Models;
using TaskManager.Domain.Entities;

namespace TaskManager.API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<UserModel> Create(User user);
        public Task<List<UserModel>> Read();
        public Task<UserModel> ReadById(Guid id);
        public Task<UserModel> Update(Guid id, User user);
        public Task<UserModel> Delete(Guid id);
    }
}
