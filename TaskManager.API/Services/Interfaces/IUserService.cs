using TaskManager.Domain.Entities;

namespace TaskManager.API.Services.Interfaces
{
    public interface IUserService
    {
        public IEnumerable<User> FindAll();
        public User Create();
    }
}
