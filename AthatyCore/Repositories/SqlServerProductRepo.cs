using AthatyCore.Entities;
using AthatyCore.Settings;

namespace AthatyCore.Repositories
{
    public class SqlServerProductRepo : IProductRepository
    {
        private AppDbContext _appDbContext;

        public SqlServerProductRepo(AppDbContext ctx)
        {
            _appDbContext = ctx;
        }

        public async Task AddProductAsync(Product product)
        {
            _appDbContext.Products.Add(product);
            await _appDbContext.SaveChangesAsync();

        }

        public Task DeleteProductAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
