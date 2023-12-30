


namespace eShop.Domain.Interfaces.Services;

public interface IProductService
{
    Task<ApiResponse<List<ProductDto>>> GetProductsAsync();
    Task<ApiResponse<ProductDto>> CreateProductAsync(NewProductReqDto productDto);

}
