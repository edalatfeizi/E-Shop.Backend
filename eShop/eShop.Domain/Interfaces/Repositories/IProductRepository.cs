
namespace eShop.Domain.Interfaces.Repositories;

public interface IProductRepository
{
    public Task<List<Product>> GetProductsAsync();
}
