using LibraryManagementSystem_FinalWebProject.Core.Models.Librarian;

namespace LibraryManagementSystem_FinalWebProject.Core.Contracts
{
    public interface ILibrarianService
    {
        Task<LibrarianQueryModel> GetLibrarians();
        Task<bool> UserWithPhoneNumberExists(string phoneNumber);
        Task<bool> ExistsById(string userId);
        Task Create(string userId, string phoneNumber);

        Task<int> GetLibrarianId(string userId);
    }
}
