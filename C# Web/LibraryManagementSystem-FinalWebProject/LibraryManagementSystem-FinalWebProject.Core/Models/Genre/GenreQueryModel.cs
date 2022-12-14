namespace LibraryManagementSystem_FinalWebProject.Core.Models.Genre
{
    public class GenreQueryModel
    {
        public int TotalGenresCount { get; set; }
        public IEnumerable<GenreModel> Genres { get; set; } = new List<GenreModel>();
    }
}
