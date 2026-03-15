using Marketplace.Catalog.Application.interfaces;
using Marketplace.Catalog.Domain.Dtos;
using Marketplace.Catalog.Domain.Entities;
using Marketplace.Catalog.Domain.Enums;
using Marketplace.Catalog.Domain.Gateways;
using Microsoft.Extensions.Logging;
using BC = BCrypt.Net.BCrypt;

namespace Marketplace.Catalog.Application.Services;

public class UserService : IUserService
{
    private readonly IUserGateway _userGateway;
    private readonly ILogger<UserService> _logger;

    public UserService(IUserGateway userGateway, ILogger<UserService> logger)
    {
        _userGateway = userGateway;
        _logger = logger;
    }

    public Task<User?> GetByIdAsync(Guid id) =>
        _userGateway.GetByIdAsync(id);

    public Task<IEnumerable<User>> GetAllAsync() =>
        _userGateway.GetAllAsync();

    public async Task CreateAsync(CreateUserRequest request)
    {
        var existing = await _userGateway.GetByEmailAsync(request.Email);

        if (existing != null)
            throw new InvalidOperationException($"Email '{request.Email}' is already in use.");

        if (!Enum.TryParse<Position>(request.Position, ignoreCase: true, out var position))
            throw new ArgumentException($"Invalid position value: '{request.Position}'.");

        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = BC.HashPassword(request.Password),
            Position = position,
            CreatedAt = DateTime.UtcNow
        };

        await _userGateway.CreateAsync(user);
        _logger.LogInformation("User created: {Email}", user.Email);
    }
}
