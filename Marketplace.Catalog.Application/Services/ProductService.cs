using Marketplace.Catalog.Application.interfaces;
using Marketplace.Catalog.Domain.Dtos;
using Marketplace.Catalog.Domain.Entities;
using Marketplace.Catalog.Domain.Gateways;
using Microsoft.Extensions.Logging;

namespace Marketplace.Catalog.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductGateway _productGateway;
    private readonly ILogger<ProductService> _logger;

    public ProductService(IProductGateway productGateway, ILogger<ProductService> logger)
    {
        _productGateway = productGateway;
        _logger = logger;
    }

    public Task<Product?> GetByIdAsync(Guid id) =>
        _productGateway.GetByIdAsync(id);

    public Task<IEnumerable<Product>> GetAllAsync() =>
        _productGateway.GetAllAsync();

    public async Task CreateAsync(CreateProductRequest request)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            ProductName = request.ProductName,
            Description = request.Description,
            PathImage = request.PathImage,
            Price = request.Price,
            Stock = request.Stock,
            Category = request.Category,
            CreatedAt = DateTime.UtcNow
        };

        await _productGateway.CreateAsync(product);
        _logger.LogInformation("Product created: {ProductName}", product.ProductName);
    }

    public async Task UpdateAsync(Guid id, CreateProductRequest request)
    {
        var existing = await _productGateway.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"Product '{id}' not found.");

        existing.ProductName = request.ProductName;
        existing.Description = request.Description;
        existing.PathImage = request.PathImage;
        existing.Price = request.Price;
        existing.Stock = request.Stock;
        existing.Category = request.Category;

        await _productGateway.UpdateAsync(id, existing);
        _logger.LogInformation("Product updated: {Id}", id);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _productGateway.DeleteAsync(id);
        _logger.LogInformation("Product deleted: {Id}", id);
    }
}
