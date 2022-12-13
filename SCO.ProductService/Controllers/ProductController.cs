using Microsoft.AspNetCore.Mvc;
using SCO.ProductService.Application.Queries;
using Microsoft.AspNetCore.Authorization;
using SCO.ProductService.Application.DTOs.Read.ProductDTOs;

namespace SCO.Api.Conrollers;
[ApiController]
[Route("product")]
public class ProductController : ControllerBase
{
    private readonly IProductQueryService _productQueryService;
    public ProductController(IProductQueryService productQueryService)
    {
        _productQueryService = productQueryService;
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public ActionResult<IEnumerable<ProductDto>> Get([FromRoute] Guid id)
    {
        var restaurant = _productQueryService.GetById(id);
        return Ok(restaurant);
    }


    [HttpGet("ProductByCategory/{categoryName}")]
    [AllowAnonymous]
    public ActionResult<IEnumerable<ProductDto>> GetRestaurantByCategory([FromRoute] string categoryName)
    {
        var restaurant = _productQueryService.GetByCategory(categoryName);
        if (restaurant is not null)
        {
            return Ok(restaurant);
        }

        return NotFound("The category does not exist or empty");
    }

    [HttpGet("ProductByName/{productName}")]
    [AllowAnonymous]
    public ActionResult<IEnumerable<ProductDto>> GetProductByName([FromRoute] string productName)
    {

        var restaurant = _productQueryService.GetByName(productName);
        if (restaurant is not null)
        {
            return Ok(restaurant);
        }

        return NotFound("The product was not found");
    }

    [HttpGet("AllProducts")]
    [AllowAnonymous]
    public ActionResult<IEnumerable<ProductDto>> GetAllProducts()
    {
        ActionResult returnResult = NotFound();

        var restaurantsDots = _productQueryService.GetAllProducts();

        if (restaurantsDots is not null)
        {
            return Ok(restaurantsDots);
        }
        return NotFound("No found products");
    }
}