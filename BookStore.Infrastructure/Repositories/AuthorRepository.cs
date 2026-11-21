
using BookStore.Core.Entities;
using BookStore.Core.Interfaces;
using BookStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get All Authors
        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _context.Authors
                .ToListAsync();
        }

        // Get Author By Id
        public async Task<Author?> GetByIdAsync(int id)
        {
            return await _context.Authors
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        // Add Author
        public async Task AddAsync(Author author)
        {
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
        }

        // Update Author
        public void Update(Author author)
        {
            _context.Authors.Update(author);
            _context.SaveChanges();
        }

        // Delete Author
        public void Delete(Author author)
        {
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }

        // Search Authors
        public async Task<IEnumerable<Author>> SearchAsync(string searchTerm)
        {
            return await _context.Authors
                .Where(a => a.Name.Contains(searchTerm))
                .ToListAsync();
        }

        // Check If Author Exists
        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Authors
                .AnyAsync(a => a.Id == id);
        }
    }
}
