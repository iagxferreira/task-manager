using Microsoft.EntityFrameworkCore;
using TaskManager.API.Models;

namespace TaskManager.API.Data
{
    public class TaskManagerDataContext(DbContextOptions<TaskManagerDataContext> options, IConfiguration configuration) : DbContext(options)
    {
        private readonly IConfiguration _configuration = configuration;

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        public DbSet<UserModel> Users { get; set; }
        public DbSet<ProjectModel> Projects { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }
    }
}
