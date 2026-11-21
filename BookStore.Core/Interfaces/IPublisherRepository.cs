
using BookStore.Core.Entities;

namespace BookStore.Core.Interfaces
{
    public interface IPublisherRepository
    {
        Task<IEnumerable<Publisher>> GetAllAsync();
        Task<Publisher?> GetByIdAsync(int id);

        Task AddAsync(Publisher publisher);
        void Update(Publisher publisher);
        void Delete(Publisher publisher);

        Task<IEnumerable<Publisher>> SearchAsync(string searchTerm);

        Task<bool> ExistsAsync(int id);
    }
}
