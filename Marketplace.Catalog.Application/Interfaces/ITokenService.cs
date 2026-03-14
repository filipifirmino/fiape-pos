using Marketplace.Catalog.Domain.Entities;

namespace Marketplace.Catalog.Application.interfaces;

public interface ITokenService
{
    string GenerateToken(User user);
    Task<User?> ValidateTokenAsync(string token);
}