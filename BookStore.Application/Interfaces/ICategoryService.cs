
using BookStore.Core.Entities;

namespace BookStore.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category?> GetCategoryByIdAsync(int id);

        Task AddCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(int id);

        Task<IEnumerable<Category>> SearchCategoriesAsync(string searchTerm);

        Task<bool> CategoryExistsAsync(int id);
    }
}
