using AutoMapper;
using TaskManager.API.Models;
using TaskManager.API.Repositories.Interfaces;
using TaskManager.Domain.Entities;

namespace TaskManager.API.Services.Interfaces
{
    public class UserService(IUserRepository repository, IMapper mapper) : IUserService
    {
        private readonly IUserRepository repository = repository;
        private readonly IMapper mapper = mapper;

        public async Task<UserModel> Create(User user)
        {
            return await repository.Create(user);
        }

        public async Task<List<UserModel>> FindAll()
        {
            return await repository.Read();
        }
    }
}
