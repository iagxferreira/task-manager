﻿using TaskManager.API.Models;
using Task = TaskManager.Domain.Entities.Task;

namespace TaskManager.API.Repositories.Interfaces
{
    public interface ITaskRepository : ICompoundModelRepository<TaskModel, Task, int, int> { }
}
