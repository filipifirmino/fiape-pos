using Marketplace.Catalog.Domain.Entities;
using Marketplace.Catalog.Domain.Gateways;
using Marketplace.Catalog.Domain.Repositories;

namespace Marketplace.Catalog.Infrastructure.Gateways;

public abstract class BaseGateway<T> : IBaseGateway<T> where T : class, IEntity
{
    private readonly IBaseRepository<T> _repository;

    protected BaseGateway(IBaseRepository<T> repository)
    {
        _repository = repository;
    }

    public Task<T?> GetByIdAsync(Guid id) => _repository.GetByIdAsync(id);
    public Task<IEnumerable<T>> GetAllAsync() => _repository.GetAllAsync();
    public Task CreateAsync(T entity) => _repository.CreateAsync(entity);
    public Task UpdateAsync(Guid id, T entity) => _repository.UpdateAsync(id, entity);
    public Task DeleteAsync(Guid id) => _repository.DeleteAsync(id);
}
