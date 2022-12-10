using LibraryManagementSystem_FinalWebProject.Core.Models.Librarian;

namespace LibraryManagementSystem_FinalWebProject.Core.Contracts
{
    public interface ILibrarianService
    {
        Task<LibrarianQueryModel> GetLibrarians();
    }
}
