using Marketplace.Catalog.Domain.Entities;

namespace Marketplace.Catalog.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
}
