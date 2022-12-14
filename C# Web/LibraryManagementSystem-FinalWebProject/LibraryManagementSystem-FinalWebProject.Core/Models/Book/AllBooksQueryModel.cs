namespace LibraryManagementSystem_FinalWebProject.Core.Models.Book
{
    public class AllBooksQueryModel
    {
        public const int BooksPerPage = 3;
        public string? Genre { get; set; }
        public string? Author { get; set; }
        public string? SearchTerm { get; set; }
        public BookSorting Sorting { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int TotalBooksCount { get; set; }
        public IEnumerable<string> Genres { get; set; } = Enumerable.Empty<string>();
        public IEnumerable<string> Authors { get; set; } = Enumerable.Empty<string>();

        public IEnumerable<BookServiceModel> Books { get; set; } = Enumerable.Empty<BookServiceModel>();
    }
}
