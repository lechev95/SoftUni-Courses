using Microsoft.AspNetCore.Identity;

namespace LibraryManagementSystem.Infrastructure.Data
{
    public class User : IdentityUser
    {

        public ICollection<UserBook>? UsersBooks { get; set; } = new List<UserBook>();
    }
}
