
namespace eShop.Infrastructure.Data;

public class EShopDbContext : DbContext
{
    public EShopDbContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<Product> Products { get; set; }
}
