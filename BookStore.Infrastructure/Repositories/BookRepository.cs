
using BookStore.Core.Entities;
using BookStore.Core.Interfaces;
using BookStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get All Books
        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Include(b => b.Publisher)
                .ToListAsync();
        }

        // Get Book By Id
        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Include(b => b.Publisher)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        // Add New Book
        public async Task AddAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        // Search Books
        public async Task<IEnumerable<Book>> SearchAsync(string searchTerm)
        {
            return await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Include(b => b.Publisher)
                .Where(b => b.Title.Contains(searchTerm) ||
                            (b.Description != null && b.Description.Contains(searchTerm)))
                .ToListAsync();
        }

        // Get Books By Category
        public async Task<IEnumerable<Book>> GetByCategoryAsync(int categoryId)
        {
            return await _context.Books
                .Where(b => b.CategoryId == categoryId)
                .ToListAsync();
        }

        // Get Books By Author
        public async Task<IEnumerable<Book>> GetByAuthorAsync(int authorId)
        {
            return await _context.Books
                .Where(b => b.AuthorId == authorId)
                .ToListAsync();
        }

        // Get Books By Publisher
        public async Task<IEnumerable<Book>> GetByPublisherAsync(int publisherId)
        {
            return await _context.Books
                .Where(b => b.PublisherId == publisherId)
                .ToListAsync();
        }

        // Get Books By Price Range
        public async Task<IEnumerable<Book>> GetByPriceRangeAsync(decimal minPrice, decimal maxPrice)
        {
            return await _context.Books
                .Where(b => b.Price >= minPrice && b.Price <= maxPrice)
                .ToListAsync();
        }

        // Update Book
        public void Update(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }

        // Delete Book
        public void Delete(Book book)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        // Check If Book Exists
        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Books
                .AnyAsync(b => b.Id == id);
        }

        // Get Books With Pagination
        public async Task<IEnumerable<Book>> GetPagedAsync(int pageNumber, int pageSize)
        {
            return await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Include(b => b.Publisher)
                .OrderBy(b => b.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

    }
}
