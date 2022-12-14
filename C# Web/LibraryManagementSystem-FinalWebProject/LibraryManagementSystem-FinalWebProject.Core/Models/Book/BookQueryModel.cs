namespace LibraryManagementSystem_FinalWebProject.Core.Models.Book
{
    public class BookQueryModel
    {
        public int TotalBooksCount { get; set; }
        public IEnumerable<BookServiceModel> Books { get; set; } = new List<BookServiceModel>();
    }
}
