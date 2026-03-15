using Marketplace.Catalog.Domain.Entities;
using Marketplace.Catalog.Domain.Repositories;
using Marketplace.Catalog.Infrastructure.Context;
using MongoDB.Driver;

namespace Marketplace.Catalog.Infrastructure.Repositories;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : class, IEntity
{
    protected readonly IMongoCollection<T> Collection;

    protected BaseRepository(MongoDbContext context, string collectionName)
    {
        Collection = context.GetCollection<T>(collectionName);
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        var filter = Builders<T>.Filter.Eq(e => e.Id, id);
        return await Collection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await Collection.Find(_ => true).ToListAsync();
    }

    public async Task CreateAsync(T entity)
    {
        await Collection.InsertOneAsync(entity);
    }

    public async Task UpdateAsync(Guid id, T entity)
    {
        var filter = Builders<T>.Filter.Eq(e => e.Id, id);
        await Collection.ReplaceOneAsync(filter, entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        var filter = Builders<T>.Filter.Eq(e => e.Id, id);
        await Collection.DeleteOneAsync(filter);
    }
}
