using Marketplace.Catalog.Domain.Enums;

namespace Marketplace.Catalog.Domain.Entities;

public class User
{
    public Guid Id {get; set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string Email {get; set;}
    public string Password {get; set;}
    public Position Position {get; set;}
    public DateTime CreatedAt {get; set;}

    public bool IsValid() => !string.IsNullOrEmpty(Email) && !string.IsNullOrWhiteSpace(Password);

}