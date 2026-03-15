using Marketplace.Catalog.Domain.Enums;

namespace Marketplace.Catalog.Domain.Entities;

public class User : IEntity
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public Position Position { get; set; }
    public DateTime CreatedAt { get; set; }

    public bool IsValid() =>
        !string.IsNullOrWhiteSpace(Email) &&
        !string.IsNullOrWhiteSpace(Password);
}
