
using System.Reflection;

namespace eShop.Infrastructure.Data;

public class EShopDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public const string DB_SCHEMA = "EShopSchema";
    public EShopDbContext(DbContextOptions<EShopDbContext> options) : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


    }

}
