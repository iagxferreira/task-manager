using Microsoft.EntityFrameworkCore;
using TaskManager.API.Data;
using TaskManager.API.Helpers;
using TaskManager.API.Repositories;
using TaskManager.API.Repositories.Interfaces;
using TaskManager.API.Services;
using TaskManager.API.Services.Interfaces;

namespace TaskManager.API.Extensions
{
    public static class WebApplicationBuilderExtension
    {
        public static WebApplicationBuilder Load(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddControllers();

            builder.Services.AddDbContext<TaskManagerDataContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

            builder.Services.AddAutoMapper(typeof(WebApplicationBuilder));

            builder.Services.AddTransient<IUserRepository, UserRepository>();
            builder.Services.AddTransient<IUserService, UserService>();

            builder.Services.AddTransient<ITaskRepository, TaskRepository>();
            builder.Services.AddTransient<ITaskService, TaskService>();

            builder.Services.AddTransient<IProjectRepository, ProjectRepository>();
            builder.Services.AddTransient<IProjectService, ProjectService>();

            builder.Services.AddExceptionHandler<ErrorHandlingHelper>();
            return builder;
        }
    }
}
