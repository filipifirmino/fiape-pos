using Marketplace.Catalog.Domain.Dtos;
using Marketplace.Catalog.Domain.Entities;

namespace Marketplace.Catalog.Application.interfaces;

public interface IProductService
{
    Task<Product?> GetByIdAsync(Guid id);
    Task<IEnumerable<Product>> GetAllAsync();
    Task CreateAsync(CreateProductRequest request);
    Task UpdateAsync(Guid id, CreateProductRequest request);
    Task DeleteAsync(Guid id);
}
