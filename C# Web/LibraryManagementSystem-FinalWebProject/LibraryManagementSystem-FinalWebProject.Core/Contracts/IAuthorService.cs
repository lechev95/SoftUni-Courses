using LibraryManagementSystem_FinalWebProject.Core.Models.Author;

namespace LibraryManagementSystem_FinalWebProject.Core.Contracts
{
    public interface IAuthorService
    {
        Task<bool> AuthorNameExists(string authorName);
        Task<int> Create(AuthorModel model);
    }
}
