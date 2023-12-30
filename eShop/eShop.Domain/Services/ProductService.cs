
namespace eShop.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepo;
        public ProductService(IProductRepository productRepo)
        {

            _productRepo = productRepo;

        }

        public async Task<ApiResponse<ProductDto>> CreateProductAsync(NewProductReqDto productDto)
        {
           var product = await _productRepo.CreateProductAsync(productDto.Name, productDto.Image, productDto.CountInStock, productDto.Description);

            var productRes = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Image = product.Image,
                Description = product.Description,
            };
            return new ApiResponse<ProductDto>(productRes);
        }

        public async Task<ApiResponse<List<ProductDto>>> GetProductsAsync()
        {
            var products = await _productRepo.GetProductsAsync();

            var productsRes = new List<ProductDto>();
            foreach (var product in products)
            {
                productsRes.Add(new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Image = product.Image,
                    Description = product.Description,
                });
            }

            return new ApiResponse<List<ProductDto>>(productsRes);

        }
    }
}
