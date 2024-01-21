using Microsoft.EntityFrameworkCore;
using TaskManager.API.Models;

namespace TaskManager.API.Data
{
    public class TaskManagerDataContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public TaskManagerDataContext(DbContextOptions<TaskManagerDataContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        public DbSet<UserModel> Users { get; set; }
    }
}
