
namespace eShop.Domain.Models;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public string RichDescription { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string Images { get; set; }
    public string Brand { get; set; }
    public decimal Price { get; set; }
    public int CountInStock { get; set; }
    public int Rating { get; set; }
    public bool IsFeatured { get; set; }
    public DateTime DateCreated { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }

}
