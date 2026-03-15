using Marketplace.Catalog.Domain.Entities;
using Marketplace.Catalog.Domain.Repositories;
using Marketplace.Catalog.Infrastructure.Context;

namespace Marketplace.Catalog.Infrastructure.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(MongoDbContext context) : base(context, "products") { }
}
