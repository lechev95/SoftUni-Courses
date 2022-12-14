using LibraryManagementSystem_FinalWebProject.Core.Models.Genre;

namespace LibraryManagementSystem_FinalWebProject.Core.Models.Publisher
{
    public class PublisherQueryModel
    {
        public int TotalPublishersCount { get; set; }
        public IEnumerable<PublisherModel> Publishers { get; set; } = new List<PublisherModel>();
    }
}
