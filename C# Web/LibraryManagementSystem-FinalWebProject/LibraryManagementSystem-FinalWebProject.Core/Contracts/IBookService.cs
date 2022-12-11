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
    }
}
