using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskManager.API.Models;
using TaskManager.API.Services.Interfaces;
using TaskManager.API.ViewModels;

namespace TaskManager.API.Controllers
{
    public class ProjectController(IProjectService service, IMapper mapper) : Controller
    {
        private readonly IProjectService service = service;
        private readonly IMapper mapper = mapper;

        [HttpGet]
        [Route("v1/projects")]
        public async Task<IActionResult> Index()
        {
            return Ok(new ResultViewModel<List<ProjectModel>>(await service.FindAll()));
        }
    }
}
