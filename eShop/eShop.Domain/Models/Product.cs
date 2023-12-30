
namespace eShop.Domain.Models;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }
    public int CountInStock { get; set; }
    public string Description { get; set; } = string.Empty;

}
