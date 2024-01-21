using TaskManager.API.Models;
using TaskManager.Domain.Entities;

namespace TaskManager.API.Services.Interfaces
{
    public interface IUserService
    {
        public Task<List<UserModel>> FindAll();
        public Task<UserModel> Create(User user);
    }
}
