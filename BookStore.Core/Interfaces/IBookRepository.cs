
using BookStore.Core.Entities;

namespace BookStore.Core.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(int id);

        Task AddAsync(Book book);
        void Update(Book book);
        void Delete(Book book);

        Task<IEnumerable<Book>> SearchAsync(string searchTerm);
        Task<IEnumerable<Book>> GetByCategoryAsync(int categoryId);
        Task<IEnumerable<Book>> GetByAuthorAsync(int authorId);
        Task<IEnumerable<Book>> GetByPublisherAsync(int publisherId);

        Task<IEnumerable<Book>> GetByPriceRangeAsync(decimal minPrice, decimal maxPrice);

        Task<IEnumerable<Book>> GetPagedAsync(int pageNumber, int pageSize);

        Task<bool> ExistsAsync(int id);
    }
}
