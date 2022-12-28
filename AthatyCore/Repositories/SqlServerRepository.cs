using AthatyCore.Entities;
using AthatyCore.Settings;
using Microsoft.EntityFrameworkCore;

namespace AthatyCore.Repositories
{
    public class SqlServerRepository : ICollectionRepository
    {
        private AppDbContext _appDbContext;

        public SqlServerRepository(AppDbContext ctx)
        {
            _appDbContext = ctx;

        }
        public async Task AddAsync<T>(T item) where T : Collection
        {
            item.Id = Guid.NewGuid().ToString();
            var collection = _appDbContext.Set<T>();
            collection.Add(item);
            await _appDbContext.SaveChangesAsync();
        }

        public IQueryable<T> AsQueryable<T>() where T : Collection
        {
            return _appDbContext.Set<T>().AsQueryable();
        }

        public async Task DeleteAsync<T>(T item) where T : Collection
        {
            var collection = _appDbContext.Set<T>();
            collection.Remove(item);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync<T>(T item) where T : Collection
        {
            var collection = _appDbContext.Set<T>();
            collection.Update(item);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
