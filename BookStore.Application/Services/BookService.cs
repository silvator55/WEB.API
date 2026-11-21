
using BookStore.Application.Interfaces;
using BookStore.Core.Entities;
using BookStore.Core.Interfaces;

namespace BookStore.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _bookRepository.GetAllAsync();
        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            return await _bookRepository.GetByIdAsync(id);
        }

        public async Task AddBookAsync(Book book)
        {
            await _bookRepository.AddAsync(book);
        }

        public async Task UpdateBookAsync(Book book)
        {
            var existingBook = await _bookRepository.GetByIdAsync(book.Id);

            if (existingBook == null)
                throw new Exception("Book not found");

            _bookRepository.Update(book);
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);

            if (book == null)
                throw new Exception("Book not found");

            _bookRepository.Delete(book);
        }

        public async Task<IEnumerable<Book>> SearchBooksAsync(string searchTerm)
        {
            return await _bookRepository.SearchAsync(searchTerm);
        }

        public async Task<IEnumerable<Book>> GetBooksByCategoryAsync(int categoryId)
        {
            return await _bookRepository.GetByCategoryAsync(categoryId);
        }

        public async Task<IEnumerable<Book>> GetBooksByAuthorAsync(int authorId)
        {
            return await _bookRepository.GetByAuthorAsync(authorId);
        }

        public async Task<IEnumerable<Book>> GetBooksByPublisherAsync(int publisherId)
        {
            return await _bookRepository.GetByPublisherAsync(publisherId);
        }

        public async Task<IEnumerable<Book>> GetBooksByPriceRangeAsync(decimal minPrice, decimal maxPrice)
        {
            return await _bookRepository.GetByPriceRangeAsync(minPrice, maxPrice);
        }

        public async Task<IEnumerable<Book>> GetPagedBooksAsync(int pageNumber, int pageSize)
        {
            return await _bookRepository.GetPagedAsync(pageNumber, pageSize);
        }

        public async Task<bool> BookExistsAsync(int id)
        {
            return await _bookRepository.ExistsAsync(id);
        }
    }
}
