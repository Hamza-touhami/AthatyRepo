using AthatyCore.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AthatyCore.Repositories
{
    public class MongoDBItemRepository : IItemRepository
    {
        private readonly IMongoCollection<Item> itemsCollection;

        private const string databaseName = "AthatyDB";
        private const string collectionName = "Items";

        private readonly FilterDefinitionBuilder<Item> filterDefinitionBuilder = Builders<Item>.Filter;

        public MongoDBItemRepository(IMongoClient mongoClient)
        {
            //Using MongoClient dependency injection to retrieve database and items collection
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(databaseName);
            itemsCollection = mongoDatabase.GetCollection<Item>(collectionName);
        }

        public async Task AddItemAsync(Item item)
        {
            await itemsCollection.InsertOneAsync(item);
        }

        public async Task DeleteItemAsync(Item item)
        {
            var filter = filterDefinitionBuilder.Eq(item => item.Id, item.Id);
            await itemsCollection.DeleteOneAsync(filter);
        }

        public async Task<Item> GetItemAsync(Guid id)
        {
            var filter = filterDefinitionBuilder.Eq(item => item.Id, id);
            return await itemsCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await itemsCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task UpdateItemAsync(Item item)
        {
            var filter = filterDefinitionBuilder.Eq(existingItem => existingItem.Id, item.Id);
            await itemsCollection.ReplaceOneAsync(filter, item);
        }
    }
}