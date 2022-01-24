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

        //Products

        Task<IEnumerable<Product>> GetProductsAsync(Guid categoryId);
        Task<Product> GetProductAsync(Guid categoryId, Guid productId);
        Task AddProductAsync(Guid categoryId, Product product);
        Task UpdateProductAsync(Guid categoryId, Product product);
        Task DeleteProductAsync(Guid categoryId, Product product);

    }
}