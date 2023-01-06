using MediatR;
using Microsoft.AspNetCore.Mvc;
using SCO.BasketService.Application.Commands;
using SCO.BasketService.Application.Queries;
using SCO.Contracts.DTOs;

namespace SCO.BasketService.Conrollers;
[ApiController]
[Route("api/[controller]")]
public class BasketController : ControllerBase
{
    private readonly IMediator _mediator;
    public BasketController( IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ItemDto>>> GetAllProductsAsync()
    {
        ActionResult returnResult = NotFound();

        var items = await _mediator.Send(new GetItemsInBasketQuery());

        if (items is not null)
        {
            return Ok(items);
        }
        return NotFound("No found products");
    }

    [HttpGet("TotalPrice")]
    public async Task<decimal> GetBasketPriceAsync()
    {
        var basketTotal = await _mediator.Send(new GetBasketPriceQuery());

        return await Task.FromResult(basketTotal.BasketPrice);
    }

    [HttpPost]
    public async void AddProductToBasket([FromBody] Guid productId)
    {
        await _mediator.Send(new AddProductToBasketCommand(productId));
    }


    [HttpDelete]
    public async void DeleteProductFromBasket([FromBody] Guid productId)
    {
        await _mediator.Send(new RemoveProductFromBasketCommand(productId));
    }

}