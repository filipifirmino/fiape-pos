
namespace Marketplace.Catalog.Domain.Entities;
public class Product
{
    public Guid Id {get; set;}
    public string ProductName {get; set;}
    public string Description {get; set;}
    public string PathImage {get; set;}
}