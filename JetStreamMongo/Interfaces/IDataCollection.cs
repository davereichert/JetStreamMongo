namespace JetStreamMongo.Interfaces
{
    public interface IDataCollection<T>
    {
        Task DeleteAsync(string id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(string id);
        Task<T> InsertOneAsync(T entity);
        Task<bool> NotAny();
        Task UpdateAsync(string id, T entity);
    }
}