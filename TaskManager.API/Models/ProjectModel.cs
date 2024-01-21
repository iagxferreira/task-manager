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

        public List<TaskModel> Tasks { get; set; } = [];


        [Required]
        public Guid UserId { get; set; }

        public virtual UserModel User { get; set; }
    }
}
