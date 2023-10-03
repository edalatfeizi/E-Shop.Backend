
namespace eShop.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly EShopDbContext _context;
    public ProductRepository(EShopDbContext dbContext)
    {
        _context = dbContext;
    }
    public async Task<List<Product>> GetProductsAsync()
    {
        var products = await _context.Products.ToListAsync();
        return products;
    }
}
