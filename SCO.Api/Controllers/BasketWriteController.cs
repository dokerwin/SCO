using Microsoft.AspNetCore.Mvc;
using SCO.Application.Commands;
using SCO.Contracts.DTOs;

namespace SCO.Api.Conrollers;
[ApiController]
[Route("receipt")]
public class BasketWriteController : ControllerBase
{
    private readonly IBasketCommandService _basketCommandService;
    public BasketWriteController(IBasketCommandService basketCommandService)
    {
        _basketCommandService = basketCommandService;
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteItemFromBasket([FromRoute] Guid id)
    {
        _basketCommandService.DeletItemFromBasket(id);
        return Ok();
    }

    [HttpPost("register")]
    public ActionResult AddItemToBasket([FromBody] ItemDto itemDto)
    {
        _basketCommandService.AddItemToBasket(itemDto);
        return Ok();
    }
}