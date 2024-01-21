using Microsoft.EntityFrameworkCore;
using TaskManager.API.Data;
using TaskManager.API.Repositories;
using TaskManager.API.Repositories.Interfaces;
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

            builder.Services.AddTransient<IUserRepository, UserRepository>();
            builder.Services.AddTransient<IUserService, UserService>();

            return builder;
        }
    }
}
