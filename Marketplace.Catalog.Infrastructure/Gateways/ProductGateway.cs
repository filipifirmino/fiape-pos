using Marketplace.Catalog.Domain.Entities;
using Marketplace.Catalog.Domain.Gateways;
using Marketplace.Catalog.Domain.Repositories;

namespace Marketplace.Catalog.Infrastructure.Gateways;

public class ProductGateway : BaseGateway<Product>, IProductGateway
{
    public ProductGateway(IProductRepository productRepository) : base(productRepository) { }
}
