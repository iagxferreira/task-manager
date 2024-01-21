using System.ComponentModel.DataAnnotations;

namespace TaskManager.API.ViewModels
{
    public class UserViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
