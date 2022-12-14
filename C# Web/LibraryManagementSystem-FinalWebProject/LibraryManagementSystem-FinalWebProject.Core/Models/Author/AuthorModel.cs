using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem_FinalWebProject.Core.Models.Author
{
    public class AuthorModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Имена")]
        [StringLength(25, MinimumLength = 2)]
        public string Name { get; set; } = null!;
        [Display(Name = "Образование")]
        [StringLength(maximumLength: 200)]
        public string? Education { get; set; }
        [Display(Name = "Биография")]
        [StringLength(maximumLength: 750)]
        public string? Biography { get; set; }
    }
}
