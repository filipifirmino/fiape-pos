using Marketplace.Catalog.Domain.Dtos;
using Marketplace.Catalog.Domain.Entities;

namespace Marketplace.Catalog.Application.interfaces;

public interface IAuthService
{
    Task<LoginResponse> AuthenticateAsync(LoginRequest request);
    Task<User> ValidateTokenAsync(string token);
    bool ValidateCredentials(string username, string password);
}