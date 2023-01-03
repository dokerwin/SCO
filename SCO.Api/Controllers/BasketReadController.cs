using Microsoft.AspNetCore.Mvc;
using SCO.Application.Queries;
using SCO.Contracts.DTOs;

namespace SCO.Api.Conrollers;
[ApiController]
[Route("receipt")]
public class BasketReadController : ControllerBase
{
    private readonly IBasketQueryService _basketQueryService;
    public BasketReadController(IBasketQueryService basketQueryService)
    {
        _basketQueryService = basketQueryService;
    }


    [HttpGet("AllProducts")]
    public ActionResult<IEnumerable<ItemDto>> GetAllProducts()
    {
        ActionResult returnResult = NotFound();

        var itemDots = _basketQueryService.GetAllProducts();

        if (itemDots is not null)
        {
            return  Ok(itemDots);
        }
        return NotFound("No found products");
    }
}