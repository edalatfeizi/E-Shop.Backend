
using eShop.Domain.Dtos.Request.Product;
using eShop.Domain.Dtos.Response.Product;
using Microsoft.AspNetCore.Authorization;

namespace eShop.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;
    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    [Authorize]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<List<ProductDto>>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetProductsAsync()
    {
        var identity = HttpContext.User.Identities.First();
        var userId = identity.Claims.Where(x => x.Type.Contains("Id")).First().Value.ToString();

        var products = await _productService.GetProductsAsync();
        return Ok(products);
    }

    [HttpPost]
    [Authorize]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<ProductDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> CreateProductAsync([FromBody] NewProductReqDto productDto)
    {
        var product = await _productService.CreateProductAsync(productDto);
        return Ok(product);
    }
}
