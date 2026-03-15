namespace Marketplace.Catalog.Domain.Dtos;

public class CreateProductRequest
{
    public string ProductName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string PathImage { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string Category { get; set; } = string.Empty;

    public bool IsValid() =>
        !string.IsNullOrWhiteSpace(ProductName) &&
        Price > 0 &&
        Stock >= 0;
}
