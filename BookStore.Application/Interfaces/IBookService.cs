
using BookStore.Core.Entities;

namespace BookStore.Application.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book?> GetBookByIdAsync(int id);

        Task AddBookAsync(Book book);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(int id);

        Task<IEnumerable<Book>> SearchBooksAsync(string searchTerm);

        Task<IEnumerable<Book>> GetBooksByCategoryAsync(int categoryId);
        Task<IEnumerable<Book>> GetBooksByAuthorAsync(int authorId);
        Task<IEnumerable<Book>> GetBooksByPublisherAsync(int publisherId);

        Task<IEnumerable<Book>> GetBooksByPriceRangeAsync(
            decimal minPrice,
            decimal maxPrice);

        Task<IEnumerable<Book>> GetPagedBooksAsync(
            int pageNumber,
            int pageSize);

        Task<bool> BookExistsAsync(int id);
    }
}
