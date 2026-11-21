
using BookStore.Core.Entities;

namespace BookStore.Application.Interfaces
{
    public interface IPublisherService
    {
        Task<IEnumerable<Publisher>> GetAllPublishersAsync();
        Task<Publisher?> GetPublisherByIdAsync(int id);

        Task AddPublisherAsync(Publisher publisher);
        Task UpdatePublisherAsync(Publisher publisher);
        Task DeletePublisherAsync(int id);

        Task<IEnumerable<Publisher>> SearchPublishersAsync(string searchTerm);

        Task<bool> PublisherExistsAsync(int id);
    }
}
