using Marketplace.Catalog.Domain.Entities;

namespace Marketplace.Catalog.Domain.Gateways;

public interface IUserGateway : IBaseGateway<User>
{
    Task<User?> GetByEmailAsync(string email);
}
