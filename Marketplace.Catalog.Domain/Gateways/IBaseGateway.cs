using Marketplace.Catalog.Domain.Entities;

namespace Marketplace.Catalog.Domain.Gateways;

public interface IBaseGateway<T> where T : class, IEntity
{
    Task<T?> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    Task CreateAsync(T entity);
    Task UpdateAsync(Guid id, T entity);
    Task DeleteAsync(Guid id);
}
