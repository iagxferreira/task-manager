
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.API.Extensions;
using TaskManager.API.Models;
using TaskManager.API.Repositories.Interfaces;
using TaskManager.API.ViewModels;
using TaskManager.Domain.Entities;

namespace TaskManager.API.Controllers
{
    [Route("v1/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(new ResultViewModel<List<UserModel>>(await _repository.Read()));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

            try
            {
                var user = await _repository.Create(new User() { Email = model.Email, Name = model.Name });
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
