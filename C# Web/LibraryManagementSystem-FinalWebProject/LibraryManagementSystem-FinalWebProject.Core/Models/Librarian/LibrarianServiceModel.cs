using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem_FinalWebProject.Core.Models.Librarian
{
    public class LibrarianServiceModel
    {
        [Display(Name = "ИД на служител")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Телефон")]
        [StringLength(15, MinimumLength = 7)]
        [Phone]
        public string PhoneNumber { get; set; } = null!;
        [EmailAddress]
        [Display(Name = "Имейл")]
        public string? Email { get; set; } = null;
        [Display(Name = "Потребителско ИД")]
        public string UserId { get; set; } = null!;
    }
}
