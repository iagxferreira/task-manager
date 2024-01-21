
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
    public class UserController(IUserService service, IMapper mapper) : ControllerBase
    {
        private readonly IUserService service = service;
        private readonly IMapper mapper = mapper;

        [HttpGet]
        [Route("v1/users")]
        public async Task<IActionResult> Index()
        {
            return Ok(new ResultViewModel<List<UserModel>>(await service.FindAll()));
        }

        [HttpPost]
        [Route("v1/user")]
        public async Task<IActionResult> Create([FromBody] UserViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

            try
            {
                var user = await service.Create(mapper.Map<User>(model));
                return Ok(new ResultViewModel<UserModel>(user));
            }
            catch (DbUpdateException)
            {
                return BadRequest(new ResultViewModel<UserModel>("Este email já está cadastrado."));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<UserModel>("Falha interna no servidor."));
            }

        }
    }
}
