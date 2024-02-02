using JetStreamMongo.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace JetStreamMongo.Data
{
    /// <summary>
    /// Generic data access wrapper for MongoDB collections.
    /// </summary>
    public class DataCollection<T> : IDataCollection<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataCollection{T}"/> class.
        /// </summary>
        /// <param name="mongoDatabase">The MongoDB database instance.</param>
        /// <param name="collectionName">The name of the collection.</param>
        public DataCollection(IMongoDatabase mongoDatabase, string collectionName)
        {
            _collection = mongoDatabase.GetCollection<T>(collectionName);
        }

        /// <summary>
        /// Retrieves all documents in the collection.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of documents.</returns>
        public async Task<IEnumerable<T>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();

        /// <summary>
        /// Retrieves a document by its identifier.
        /// </summary>
        /// <param name="id">The document identifier.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the document if found; otherwise, null.</returns>
        public async Task<T?> GetByIdAsync(string id)
        {
            return await _collection.Find(Builders<T>.Filter.Eq("_id", new ObjectId(id))).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Inserts a new document into the collection.
        /// </summary>
        /// <param name="entity">The document to insert.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the inserted document.</returns>
        public async Task<T> InsertOneAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        /// <summary>
        /// Updates an existing document in the collection.
        /// </summary>
        /// <param name="id">The document identifier.</param>
        /// <param name="entity">The document with updated fields.</param>
        /// <returns>A task that represents the asynchronous update operation.</returns>
        public async Task UpdateAsync(string id, T entity)
        {
            await _collection.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", new ObjectId(id)), entity);
        }

        /// <summary>
        /// Deletes a document from the collection.
        /// </summary>
        /// <param name="id">The document identifier to delete.</param>
        /// <returns>A task that represents the asynchronous delete operation.</returns>
        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("_id", new ObjectId(id)));
        }

        /// <summary>
        /// Checks if the collection is empty.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a boolean value indicating if the collection is empty.</returns>
        public async Task<bool> NotAny()
        {
            return await _collection.CountDocumentsAsync(Builders<T>.Filter.Empty) == 0;
        }

        /// <summary>
        /// Finds a single document matching the provided filter expression.
        /// </summary>
        /// <param name="filterExpression">The filter expression.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the found document or null.</returns>
        public async Task<T> FindOneAsync(Expression<Func<T, bool>> filterExpression)
        {
            return await _collection.Find(filterExpression).FirstOrDefaultAsync();
        }
    }
}
