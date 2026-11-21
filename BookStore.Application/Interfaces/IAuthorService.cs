
using BookStore.Core.Entities;

namespace BookStore.Application.Interfaces
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAllAuthorsAsync();
        Task<Author?> GetAuthorByIdAsync(int id);

        Task AddAuthorAsync(Author author);
        Task UpdateAuthorAsync(Author author);
        Task DeleteAuthorAsync(int id);

        Task<IEnumerable<Author>> SearchAuthorsAsync(string searchTerm);

        Task<bool> AuthorExistsAsync(int id);
    }
}
