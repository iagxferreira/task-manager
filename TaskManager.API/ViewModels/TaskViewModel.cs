using System.ComponentModel.DataAnnotations;
using TaskManager.Domain.Enum;

namespace TaskManager.API.ViewModels
{
    public class TaskViewModel
    {
        [Required]
        public int ProjectId { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public EStatusType Status { get; set; } = EStatusType.PENDING;
    }
}
