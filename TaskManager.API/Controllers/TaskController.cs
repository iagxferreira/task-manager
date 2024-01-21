using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.API.Extensions;
using TaskManager.API.Models;
using TaskManager.API.Services.Interfaces;
using TaskManager.API.ViewModels;
using TaskManager.Domain.Entities;
using Task = TaskManager.Domain.Entities.Task;

namespace TaskManager.API.Controllers
{
    public class TaskController(ITaskService service, IMapper mapper) : Controller
    {
        private readonly ITaskService service = service;
        private readonly IMapper mapper = mapper;

        [HttpGet]
        [Route("v1/tasks")]
        public async Task<IActionResult> Index()
        {
            return Ok(new ResultViewModel<List<TaskModel>>(await service.FindAll()));
        }

        [HttpPost]
        [Route("v1/task")]
        public async Task<IActionResult> Create([FromBody] TaskViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

            try
            {
                var task = await service.Create(new Task { Title = model.Title, Description = model.Description, DueDate = model.DueDate, Status = model.Status }, model.ProjectId);
                return Ok(new ResultViewModel<ProjectModel>(task));
            }
            catch (DbUpdateException)
            {
                return BadRequest(new ResultViewModel<TaskModel>("Este email já está cadastrado."));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<TaskModel>("Falha interna no servidor."));
            }

        }
    }
}
