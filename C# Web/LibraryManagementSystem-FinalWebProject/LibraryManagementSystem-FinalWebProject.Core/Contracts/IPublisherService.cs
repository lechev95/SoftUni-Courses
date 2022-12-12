using LibraryManagementSystem_FinalWebProject.Core.Models.Publisher;

namespace LibraryManagementSystem_FinalWebProject.Core.Contracts
{
    public interface IPublisherService
    {
        Task<bool> PublisherExists(string publisherName);
        Task<int> Create(PublisherModel model);
    }
}
