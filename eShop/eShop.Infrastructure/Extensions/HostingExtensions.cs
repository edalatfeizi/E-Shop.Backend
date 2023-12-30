
namespace eShop.Infrastructure.Extensions;

public static class HostingExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<EShopDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IProductRepository,ProductRepository>();
        services.AddScoped<IAccountRepository,AccountRepository>();
        services.AddScoped(typeof(EShopRepository<>));

        return services;
    }
}
