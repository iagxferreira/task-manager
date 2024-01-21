using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskManager.Domain.Enum;

namespace TaskManager.API.Models
{
    [Table("Tasks")]
    public class TaskModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public EStatusType Status { get; set; } = EStatusType.PENDING;

        [Required]
        public int ProjectId { get; set; }

        [Required]
        public virtual ProjectModel Project { get; set; }
    }
}
