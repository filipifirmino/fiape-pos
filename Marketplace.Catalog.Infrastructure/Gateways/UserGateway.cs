using Marketplace.Catalog.Domain.Entities;
using Marketplace.Catalog.Domain.Gateways;
using Marketplace.Catalog.Domain.Repositories;

namespace Marketplace.Catalog.Infrastructure.Gateways;

public class UserGateway : BaseGateway<User>, IUserGateway
{
    private readonly IUserRepository _userRepository;

    public UserGateway(IUserRepository userRepository) : base(userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<User?> GetByEmailAsync(string email) =>
        _userRepository.GetByEmailAsync(email);
}
