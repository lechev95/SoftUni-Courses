using LibraryManagementSystem_FinalWebProject.Core.Models.Publisher;

namespace LibraryManagementSystem_FinalWebProject.Core.Contracts
{
    public interface IPublisherService
    {
        Task<bool> PublisherExists(string publisherName);
        Task<int> Create(PublisherModel model);
        Task<bool> PublisherExistsById(int publisherId);
        Task<int> GetPublisherId(int publisherId);
        Task<PublisherQueryModel> GetPublishers();
        Task Edit(int publisherId, PublisherModel model);

    }
}
