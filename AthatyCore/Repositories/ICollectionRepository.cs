using AthatyCore.Entities;
using System.Linq.Expressions;

namespace AthatyCore.Repositories
{
    public interface ICollectionRepository
    {
        IQueryable<T> AsQueryable<T>() where T : Collection;


        Task AddAsync<T>(T item) where T : Collection;
        Task UpdateAsync<T>(T item) where T : Collection;
        Task DeleteAsync<T>(T item) where T : Collection;
    }
}