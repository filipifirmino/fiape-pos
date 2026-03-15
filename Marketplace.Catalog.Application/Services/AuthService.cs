using System.Security.Authentication;
using Marketplace.Catalog.Application.interfaces;
using Marketplace.Catalog.Domain.Dtos;
using Marketplace.Catalog.Domain.Entities;
using Marketplace.Catalog.Domain.Gateways;
using Microsoft.Extensions.Logging;
using BC = BCrypt.Net.BCrypt;

namespace Marketplace.Catalog.Application.Services;

public class AuthService : IAuthService
{
    private readonly ITokenService _tokenService;
    private readonly IUserGateway _userGateway;
    private readonly ILogger<AuthService> _logger;

    public AuthService(ITokenService tokenService, IUserGateway userGateway, ILogger<AuthService> logger)
    {
        _tokenService = tokenService;
        _userGateway = userGateway;
        _logger = logger;
    }

    public async Task<LoginResponse?> AuthenticateAsync(LoginRequest request)
    {
        try
        {
            _logger.LogInformation("Authentication attempt for: {Email}", request.Email);

            var user = await _userGateway.GetByEmailAsync(request.Email);

            if (user == null || !BC.Verify(request.Password, user.Password))
            {
                _logger.LogWarning("Invalid credentials for: {Email}", request.Email);
                return null;
            }

            var expirationMinutes = 60;
            var token = _tokenService.GenerateToken(user);

            _logger.LogInformation("User authenticated: {Email}", request.Email);

            return new LoginResponse
            {
                Token = token,
                Username = user.FirstName,
                ExpiresIn = expirationMinutes * 60,
                ExpiresAt = DateTime.UtcNow.AddMinutes(expirationMinutes)
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error during authentication for: {Email}", request.Email);
            throw new AuthenticationException("Internal error during authentication");
        }
    }

    public async Task<User?> ValidateTokenAsync(string token)
    {
        try
        {
            return await _tokenService.ValidateTokenAsync(token);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error during token validation");
            return null;
        }
    }
}
