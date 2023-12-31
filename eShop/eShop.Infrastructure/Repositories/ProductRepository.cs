
namespace eShop.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly EShopDbContext _context;
    public ProductRepository(EShopDbContext dbContext)
    {
        _context = dbContext;
    }

    public async Task<Product> CreateProductAsync(string name, string Image, int countInStock, string description)
    {
        var product = new Product { Name = name, Image = Image, CountInStock = countInStock, Description = description };

        _context.Add(product);
        await _context.SaveChangesAsync();

        return product;
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        var products = await _context.Set<Product>().ToListAsync();
        return products;
    }
}
