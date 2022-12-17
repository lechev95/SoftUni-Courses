using LibraryManagementSystem_FinalWebProject.Core.Contracts;

namespace LibraryManagementSystem.Core.Models.Book
{
    public class BookHomeModel : IBookModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}
