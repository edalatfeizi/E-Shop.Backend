
namespace eShop.Domain.Interfaces.Services;

public interface IProductService
{
    Task<List<Product>> GetProductsAsync();
}
