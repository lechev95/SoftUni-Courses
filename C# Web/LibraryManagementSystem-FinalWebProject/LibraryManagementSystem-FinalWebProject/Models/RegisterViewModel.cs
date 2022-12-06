using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem_FinalWebProject.Models
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 5)]
        [Display(Name = "Потребител")]
        public string UserName { get; set; } = null!;

        [Required]
        [StringLength(20, MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; } = null!;

        [Required]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        [Display(Name = "Потвърди парола")]
        public string ConfirmPassword { get; set; } = null!;

        [Required]
        [StringLength(60, MinimumLength = 10)]
        [EmailAddress]
        [Display(Name = "Имейл адрес")]
        public string Email { get; set; } = null!;
    }
}
