using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem_FinalWebProject.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Потребител")]
        public string UserName { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; } = null!;
    }
}
