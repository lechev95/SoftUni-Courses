using LibraryManagementSystem_FinalWebProject.Core.Models.Genre;

namespace LibraryManagementSystem_FinalWebProject.Core.Contracts
{
    public interface IGenreService
    {
        Task<bool> GenreExists(string genreName);
        Task<int> Create(GenreModel model);
        Task<bool> GenreExistsById(int genreId);
        Task<int> GetGenreId(int genreId);
        Task<GenreQueryModel> GetGenres();
        Task Edit(int genreId, GenreModel model);

    }
}
