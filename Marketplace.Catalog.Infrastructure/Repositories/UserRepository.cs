using Marketplace.Catalog.Domain.Entities;
using Marketplace.Catalog.Domain.Repositories;
using Marketplace.Catalog.Infrastructure.Context;
using MongoDB.Driver;

namespace Marketplace.Catalog.Infrastructure.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(MongoDbContext context) : base(context, "users") { }

    public async Task<User?> GetByEmailAsync(string email)
    {
        var filter = Builders<User>.Filter.Eq(u => u.Email, email);
        return await Collection.Find(filter).FirstOrDefaultAsync();
    }
}
