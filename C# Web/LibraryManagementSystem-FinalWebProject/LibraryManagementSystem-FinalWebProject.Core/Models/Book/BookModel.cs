using LibraryManagementSystem_FinalWebProject.Core.Contracts;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem_FinalWebProject.Core.Models.Book
{
    public class BookModel : IBookModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "ИСБН")]
        [StringLength(maximumLength: 20, MinimumLength = 7)]
        public string Isbn { get; set; } = null!;

        [Required]
        [Display(Name = "Заглавие")]
        [StringLength(maximumLength: 50, MinimumLength = 5)]
        public string Title { get; set; } = null!;

        [Required]
        [Display(Name = "Автор")]
        public int AuthorId { get; set; }

        public IEnumerable<BookAuthorModel> Authors { get; set; } = new List<BookAuthorModel>();

        [Required]
        [Display(Name = "Жанр")]
        public int GenreId { get; set; }

        public IEnumerable<BookGenreModel> Genres { get; set; } = new List<BookGenreModel>();

        [Required]
        [Display(Name = "Количество")]
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Цена")]
        [Range(0.00, 150.00, ErrorMessage = "Цената трябва да бъде положително число")]
        [Precision(18, 2)]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Издателство")]
        public int PublisherId { get; set; }
        public IEnumerable<BookPublisherModel> Publishers { get; set; } = new List<BookPublisherModel>();

        [Display(Name = "Дата на получаване")]
        public DateTime DateReceived { get; set; }

        [Display(Name = "Описание")]
        [StringLength(maximumLength: 500, MinimumLength = 50)]
        public string? Description { get; set; }

        [Required]
        [Display(Name = "Корица")]
        public string ImageUrl { get; set; } = null!;
    }
}
