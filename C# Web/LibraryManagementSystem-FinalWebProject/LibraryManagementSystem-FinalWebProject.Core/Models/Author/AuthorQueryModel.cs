namespace LibraryManagementSystem_FinalWebProject.Core.Models.Author
{
    public class AuthorQueryModel
    {
        public int TotalAuthorsCount { get; set; }
        public IEnumerable<AuthorModel> Authors { get; set; } = new List<AuthorModel>();
    }
}
