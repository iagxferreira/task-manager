using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.API.Models
{
    [Table("Projects")]
    public class ProjectModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public Guid UserId { get; set; }
        public virtual UserModel User { get; set; }
        public ICollection<TaskModel> Tasks { get; } = new List<TaskModel>();

    }
}
