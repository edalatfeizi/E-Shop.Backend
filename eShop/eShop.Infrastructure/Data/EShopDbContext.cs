
namespace eShop.Infrastructure.Data;

public class EShopDbContext : IdentityDbContext
{
    public EShopDbContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<Product> Products { get; set; }
}
