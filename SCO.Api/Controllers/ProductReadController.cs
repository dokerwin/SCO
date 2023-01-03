using Microsoft.AspNetCore.Mvc;
using SCO.Application.Queries;
using SCO.Contracts.DTOs;

namespace SCO.Api.Conrollers;

[ApiController]
[Route("product")]
public class ProductReadController : ControllerBase
{
    private readonly IProductQueryService _productQueryService;
    public ProductReadController(IProductQueryService productQueryService)
    {
        _productQueryService = productQueryService;
    }

    [HttpGet("AllProducts")]
    public ActionResult<IEnumerable<ItemDto>> GetAllProducts()
    {
        ActionResult returnResult = NotFound();

        var itemDots = _productQueryService.GetAllProducts();

        if (itemDots is not null)
        {
            return Ok(itemDots);
        }
        return NotFound("No found products");
    }

    [HttpGet("ProductsByCategory/{categoryName}")]
    public ActionResult<IEnumerable<ItemDto>> GetProductsByCategory([FromRoute] string categoryName)
    {
        ActionResult returnResult = NotFound();

        var itemDots = _productQueryService.GetByCategory(categoryName);

        if (itemDots is not null)
        {
            return Ok(itemDots);
        }
        return NotFound("No found products");
    }

    [HttpGet("ProductsByName/{productName}")]
    public ActionResult<IEnumerable<ItemDto>> GetProductsByName([FromRoute] string productName)
    {
        ActionResult returnResult = NotFound();

        var itemDots = _productQueryService.GetByName(productName);

        if (itemDots is not null)
        {
            return Ok(itemDots);
        }
        return NotFound("No found products");
    }

}