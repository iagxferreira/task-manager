using System.ComponentModel.DataAnnotations;

namespace TaskManager.API.ViewModels
{
    public class ProjectViewModel
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
