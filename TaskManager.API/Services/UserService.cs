using TaskManager.API.Repositories.Interfaces;
using TaskManager.Domain.Entities;

namespace TaskManager.API.Services.Interfaces
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            this._repository = repository;
        }

        public User Create()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> FindAll()
        {
            throw new NotImplementedException();
        }
    }
}
