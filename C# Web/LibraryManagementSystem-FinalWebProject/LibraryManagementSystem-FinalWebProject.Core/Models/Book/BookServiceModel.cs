using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem_FinalWebProject.Core.Models.Book
{
    public class BookServiceModel
    {
        public int Id { get; init; }
        [Display(Name = "Заглавие")]
        public string Title { get; init; } = null!;
        [Display(Name = "Количество")]
        public int Quantity { get; init; }
        [Display(Name = "Цена")]
        public decimal Price { get; init; }
        [Display(Name = "Наеми")]
        public bool IsRented { get; init; }
        [Display(Name = "Корица")]
        public string ImageUrl { get; init; } = null!;
        [Display(Name = "Автор")]
        public IEnumerable<BookAuthorModel> Authors { get; init; } = new List<BookAuthorModel>();
        [Display(Name = "Жанр")]
        public IEnumerable<BookGenreModel> Genres { get; init; } = new List<BookGenreModel>();
    }
}
