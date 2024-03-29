﻿using TaskManager.API.Models;
using TaskManager.Domain.Entities;

namespace TaskManager.API.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<UserModel, User, Guid> { }
}
