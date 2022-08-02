using AthatyCore.Entities;

namespace AthatyCore.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> GetCategoryAsync(Guid id);
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task AddCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(Category category);

    }
}