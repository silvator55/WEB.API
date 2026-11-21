
using BookStore.Core.Entities;

namespace BookStore.Core.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);

        Task AddAsync(Category category);
        void Update(Category category);
        void Delete(Category category);

        Task<IEnumerable<Category>> SearchAsync(string searchTerm);

        Task<bool> ExistsAsync(int id);
    }
}
