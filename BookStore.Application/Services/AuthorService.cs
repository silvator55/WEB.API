
using BookStore.Application.Interfaces;
using BookStore.Core.Entities;
using BookStore.Core.Interfaces;

namespace BookStore.Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
        {
            return await _authorRepository.GetAllAsync();
        }

        public async Task<Author?> GetAuthorByIdAsync(int id)
        {
            return await _authorRepository.GetByIdAsync(id);
        }

        public async Task AddAuthorAsync(Author author)
        {
            await _authorRepository.AddAsync(author);
        }

        public async Task UpdateAuthorAsync(Author author)
        {
            var existingAuthor = await _authorRepository.GetByIdAsync(author.Id);

            if (existingAuthor == null)
                throw new Exception("Author not found");

            _authorRepository.Update(author);
        }

        public async Task DeleteAuthorAsync(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);

            if (author == null)
                throw new Exception("Author not found");

            _authorRepository.Delete(author);
        }

        public async Task<IEnumerable<Author>> SearchAuthorsAsync(string searchTerm)
        {
            return await _authorRepository.SearchAsync(searchTerm);
        }

        public async Task<bool> AuthorExistsAsync(int id)
        {
            return await _authorRepository.ExistsAsync(id);
        }
    }
}
