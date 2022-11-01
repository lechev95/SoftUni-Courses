using Microsoft.AspNetCore.Identity;

namespace LibraryManagementSystem_FinalWebProject.Data.Models
{
    public class User : IdentityUser
    {

        public ICollection<UserBook>? UsersBooks { get; set; } = new List<UserBook>();
    }
}
