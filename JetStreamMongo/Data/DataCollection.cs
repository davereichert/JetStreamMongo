using JetStreamMongo.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace JetStreamMongo.Data
{
    public class DataCollection<T> : IDataCollection<T>
    {
        private readonly IMongoCollection<T> _collection;

        public DataCollection(IMongoDatabase mongoDatabase, string collectionName)
        {
            _collection = mongoDatabase.GetCollection<T>(collectionName);
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();

        public async Task<T?> GetByIdAsync(string id)
        {
            return await _collection.Find(Builders<T>.Filter.Eq("_id", new ObjectId(id))).FirstOrDefaultAsync();
        }

        public async Task<T> InsertOneAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        // muss geändert werden
        public async Task UpdateAsync(string id, T entity)
        {
            await _collection.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", new ObjectId(id)), entity);
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("_id", new ObjectId(id)));
        }

        public async Task<bool> NotAny()
        {
            return await _collection.CountDocumentsAsync(Builders<T>.Filter.Empty) <= 0;
        }

    }

}
