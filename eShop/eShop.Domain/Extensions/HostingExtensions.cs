
namespace eShop.Domain.Extentions;

public static class HostingExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        return services;
    }
}
