using LibraryManagementSystem_FinalWebProject.Core.Models.Author;
using LibraryManagementSystem_FinalWebProject.Core.Models.Librarian;

namespace LibraryManagementSystem_FinalWebProject.Core.Models.Book
{
    public class BookDetailsModel : BookServiceModel
    {
        public string? Description { get; set; } 
        public string? Genre { get; set; }
        public LibrarianServiceModel Librarian { get; set; }
        public AuthorModel Author { get; set; }

    }
}
