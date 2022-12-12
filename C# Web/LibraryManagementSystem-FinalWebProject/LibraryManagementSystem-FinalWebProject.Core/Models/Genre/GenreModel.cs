using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem_FinalWebProject.Core.Models.Genre
{
    public class GenreModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Име на жанр")]
        [StringLength(30, MinimumLength = 5)]
        public string GenreName { get; set; } = null!;
    }
}
