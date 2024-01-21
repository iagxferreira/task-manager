using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.API.Extensions;
using TaskManager.API.Models;
using TaskManager.API.Services.Interfaces;
using TaskManager.API.ViewModels;
using TaskManager.Domain.Entities;

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

        [HttpPost]
        [Route("v1/project")]
        public async Task<IActionResult> Create([FromBody] ProjectViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

            try
            {
                var project = await service.Create(new Project { Name= model.Name }, model.UserId);
                return Ok(new ResultViewModel<ProjectModel>(project));
            }
            catch (DbUpdateException)
            {
                return BadRequest(new ResultViewModel<ProjectModel>("Este projeto já está cadastrado."));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<ProjectModel>("Falha interna no servidor."));
            }
        }

        [HttpGet]
        [Route("v1/project/{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(new ResultViewModel<ProjectModel>(await service.FindById(id)));
        }
    }
}
