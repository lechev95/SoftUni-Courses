namespace LibraryManagementSystem_FinalWebProject.Core.Models.Librarian
{
    public class LibrarianQueryModel
    {
        public int TotalLibrariansCount { get; set; }
        public IEnumerable<LibrarianServiceModel> Librarians { get; set; } = new List<LibrarianServiceModel>();

    }
}
