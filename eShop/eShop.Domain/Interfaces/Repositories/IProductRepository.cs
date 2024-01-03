
using eShop.Domain.Entities;

namespace eShop.Domain.Interfaces.Repositories;

public interface IProductRepository
{
    Task<List<Product>> GetProductsAsync();
    Task<Product> CreateProductAsync(string name, string Image, int countInStock, string description);
}
