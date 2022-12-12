using LibraryManagementSystem_FinalWebProject.Core.Models.Genre;

namespace LibraryManagementSystem_FinalWebProject.Core.Contracts
{
    public interface IGenreService
    {
        Task<bool> GenreExists(string genreName);
        Task<int> Create(PublisherModel model);

    }
}
