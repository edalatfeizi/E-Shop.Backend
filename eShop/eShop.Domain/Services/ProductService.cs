
namespace eShop.Domain.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;
    public ProductService(IProductRepository productRepository)
    {
        _repository = productRepository;
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        var products =  await _repository.GetProductsAsync();
        return products;
    }
}
