using Microsoft.AspNetCore.Mvc;
using SCO.BasketService.Application.Queries;
using Microsoft.AspNetCore.Authorization;
using SCO.ProductService.Application.DTOs.Read.ProductDTOs;


namespace SCO.BasketService.Conrollers;
[ApiController]
[Route("basket")]
public class ProductController : ControllerBase
{
    private readonly IBasketQueryService _basketQueryService;
    public ProductController(IBasketQueryService productQueryService)
    {
        _basketQueryService = productQueryService;
    }

    [HttpGet("AllProducts")]
    public ActionResult<IEnumerable<ProductDto>> GetAllProducts()
    {
        ActionResult returnResult = NotFound();

        var items = _basketQueryService.GetAllProducts();

        if (items is not null)
        {
            return Ok(items);
        }
        return NotFound("No found products");
    }


    [HttpGet("GetPrice")]
    public decimal GetBasketPrice()
    {
        ActionResult returnResult = NotFound();

        decimal basket = _basketQueryService.GetBasketPrice();

        return basket;
    }
}