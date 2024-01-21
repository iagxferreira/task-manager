using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskManager.API.Models;
using TaskManager.API.Services.Interfaces;
using TaskManager.API.ViewModels;

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
    }
}
