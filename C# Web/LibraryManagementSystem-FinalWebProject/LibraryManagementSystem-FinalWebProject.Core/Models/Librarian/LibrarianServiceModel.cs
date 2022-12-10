using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem_FinalWebProject.Core.Models.Librarian
{
    public class LibrarianServiceModel
    {
        [Display(Name = "ИД на служител")]
        public int Id { get; set; }
        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; } = null!;
        [Display(Name = "Потребителско ИД")]
        public string UserId { get; set; } = null!;
    }
}
