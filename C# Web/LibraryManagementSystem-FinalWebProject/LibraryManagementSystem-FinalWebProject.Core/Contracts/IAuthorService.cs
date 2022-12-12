using LibraryManagementSystem_FinalWebProject.Core.Models.Author;

namespace LibraryManagementSystem_FinalWebProject.Core.Contracts
{
    public interface IAuthorService
    {
        Task<bool> AuthorFirstNameExists(string authorFirstName);
        Task<bool> AuthorLastNameExists(string authorLastName);
        Task<int> Create(AuthorModel model);
    }
}
