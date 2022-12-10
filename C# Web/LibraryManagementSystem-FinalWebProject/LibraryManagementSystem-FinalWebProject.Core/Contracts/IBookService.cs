using LibraryManagementSystem.Core.Models.Book;

namespace LibraryManagementSystem_FinalWebProject.Core.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<BookHomeModel>> LastFiveBooks();
    }
}
