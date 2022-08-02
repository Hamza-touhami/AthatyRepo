using AthatyCore.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AthatyCore.Repositories
{
    public class MongoDBCategoryRepository : ICategoryRepository
    {
        private readonly IMongoCollection<Category> categoryCollection;

        private const string databaseName = "AthatyDB";
        private const string collectionName = "Categories";

        private readonly FilterDefinitionBuilder<Category> filterDefinitionBuilder = Builders<Category>.Filter;
        private readonly FilterDefinitionBuilder<Product> filterDefinitionBuilderProduct = Builders<Product>.Filter;

        public MongoDBCategoryRepository(IMongoClient mongoClient)
        {
            //Using MongoClient dependency injection to retrieve database and items collection
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(databaseName);
            categoryCollection = mongoDatabase.GetCollection<Category>(collectionName);
        }

        public async Task AddCategoryAsync(Category category)
        {
            await categoryCollection.InsertOneAsync(category);
        }

        public async Task DeleteCategoryAsync(Category category)
        {
            var filter = filterDefinitionBuilder.Eq(category => category.Id, category.Id);
            await categoryCollection.DeleteOneAsync(filter);
        }

        public async Task<Category> GetCategoryAsync(Guid id)
        {
            var filter = filterDefinitionBuilder.Eq(Category => Category.Id, id);
            return await categoryCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await categoryCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            var filter = filterDefinitionBuilder.Eq(existingCategory => existingCategory.Id, category.Id);
            await categoryCollection.ReplaceOneAsync(filter, category);
        }
    }
}