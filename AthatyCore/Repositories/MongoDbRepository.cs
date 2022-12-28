using AthatyCore.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace AthatyCore.Repositories
{
    
    public class MongoDbRepository : ICollectionRepository
    {
        private readonly IMongoDatabase mongoDatabase;
        private const string databaseName = "AthatyDB";

//        private readonly FilterDefinitionBuilder<T> filterDefinitionBuilder = Builders<T>.Filter;

        public MongoDbRepository(IMongoClient mongoClient)
        {
            //Using MongoClient dependency injection to retrieve database and items collection
            mongoDatabase = mongoClient.GetDatabase(databaseName);
        }

        public IQueryable<T> AsQueryable<T>() where T : Collection
        {
            var collection = mongoDatabase.GetCollection<T>(GetCollectionName<T>());
            return collection.AsQueryable();
        }

        public async Task AddAsync<T>(T item) where T : Collection
        {
            var collection = mongoDatabase.GetCollection<T>(GetCollectionName<T>());
            item.Id = (Guid.NewGuid()).ToString();
            await collection.InsertOneAsync(item);
        }

        public async Task DeleteAsync<T>(T item) where T : Collection
        {
            FilterDefinitionBuilder<T> filterDefinitionBuilder = Builders<T>.Filter;
            var filter = filterDefinitionBuilder.Eq(item => item.Id, item.Id);
            var collection = mongoDatabase.GetCollection<T>(GetCollectionName<T>());
            await collection.DeleteOneAsync(filter);
        }

        public async Task UpdateAsync<T>(T item) where T : Collection
        {
            FilterDefinitionBuilder<T> filterDefinitionBuilder = Builders<T>.Filter;
            var filter = filterDefinitionBuilder.Eq(existingItem => existingItem.Id, item.Id);
            var collection = mongoDatabase.GetCollection<T>(GetCollectionName<T>());
            await collection.ReplaceOneAsync(filter, item);
        }

        private string GetCollectionName<T>() where T : Collection
        {
            var type = typeof(T).Name;
            switch(type)
            {
                case "Item":
                    return "Items";
                case "Product":
                    return "Products";
                case "Category":
                    return "Categories";
            }

            return null;
        }
    }
}