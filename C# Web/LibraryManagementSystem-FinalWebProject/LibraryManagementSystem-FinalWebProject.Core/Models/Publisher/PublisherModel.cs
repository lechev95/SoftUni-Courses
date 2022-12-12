using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem_FinalWebProject.Core.Models.Genre
{
    public class PublisherModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Име на издател")]
        [StringLength(50, MinimumLength = 3)]
        public string PublisherName { get; set; } = null!;
    }
}
