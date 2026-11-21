
using BookStore.Core.Entities;

namespace BookStore.Core.Interfaces
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAsync();
        Task<Author?> GetByIdAsync(int id);

        Task AddAsync(Author author);
        void Update(Author author);
        void Delete(Author author);

        Task<IEnumerable<Author>> SearchAsync(string searchTerm);

        Task<bool> ExistsAsync(int id);
    }
}
