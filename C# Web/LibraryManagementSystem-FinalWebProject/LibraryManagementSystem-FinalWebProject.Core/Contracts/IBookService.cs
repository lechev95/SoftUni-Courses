using LibraryManagementSystem.Core.Models.Book;
using LibraryManagementSystem_FinalWebProject.Core.Models.Book;

namespace LibraryManagementSystem_FinalWebProject.Core.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<BookHomeModel>> LastFiveBooks();

        Task<IEnumerable<BookGenreModel>> AllGenres();

        Task<IEnumerable<BookAuthorModel>> AllAuthors();

        Task<IEnumerable<BookPublisherModel>> AllPublishers();

        Task<bool> GenreExists(int genreId);

        Task<bool> AuthorExists(int authorId);

        Task<bool> PublisherExists(int publisherId);

        Task<int> Create(BookModel model, int librarianId);

        Task<BookQueryModel> All(
            string? genre = null,
            string? searchTerm = null,
            string? author = null,
            BookSorting sorting = BookSorting.Newest,
            int currentPage = 1,
            int booksPerPage = 1);

        Task<IEnumerable<string>> AllGenresNames();
        Task<IEnumerable<string>> AllAuthorsNames();
    }
}
