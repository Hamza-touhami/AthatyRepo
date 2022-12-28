using AthatyCore.Entities;
using AthatyCore.Settings;

namespace AthatyCore.Repositories
{
    public class SqlServerItemRepo : IItemRepository
    {
        private AppDbContext _appDbContext;

        public SqlServerItemRepo(AppDbContext ctx)
        {
            _appDbContext = ctx;
        }
        public Task AddItemAsync(Item item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteItemAsync(Item item)
        {
            throw new NotImplementedException();
        }

        public Task<Item> GetItemAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Item>> GetItemsAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateItemAsync(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
