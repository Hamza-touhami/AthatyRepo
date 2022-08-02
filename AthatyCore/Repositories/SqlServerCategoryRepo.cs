using AthatyCore.Entities;
using AthatyCore.Settings;

namespace AthatyCore.Repositories
{
    public class SqlServerCategoryRepo : ICategoryRepository
    {
        private AppDbContext _appDbContext;

        public SqlServerCategoryRepo(AppDbContext ctx)
        {
            _appDbContext = ctx;
        }
        public async Task AddCategoryAsync(Category category)
        {
            _appDbContext.Categories.Add(category);
            await _appDbContext.SaveChangesAsync();
        }

        public Task DeleteCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }

       
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return _appDbContext.Categories.ToList();
        }

        public Task<Category> GetCategoryAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductsAsync(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }

    }
}
