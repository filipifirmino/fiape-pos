namespace Marketplace.Catalog.Domain.Dtos;

public class LoginRequest
{
    public string Email {get; set;}
    public string Password {get; set;}

    public bool IsValid()
    {
        return Email != null && !Email.IsNormalized() && Password != null && !Password.IsNormalized();
    }
    
}