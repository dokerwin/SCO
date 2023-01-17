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
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProductsAsync()
    {
        ActionResult returnResult = NotFound();

        var items = await _mediator.Send(new GetBasketDetailsQuery());

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

    [HttpPost("OpenOrder")]
    public async void OpenOrder()
    {
        await _mediator.Send(new OpenOrderCommand());
    }

    [HttpPost("AbortOrder")]
    public async void AbortOrder()
    {
        await _mediator.Send(new AbortOrderCommand());
    }

    [HttpPost("FinishOrder")]
    public async void FinishOrder()
    {
        await _mediator.Send(new FinishOrderCommand());
    }

    [HttpDelete]
    public async void DeleteProductFromBasket([FromBody] Guid productId)
    {
        await _mediator.Send(new RemoveProductFromBasketCommand(productId));
    }

}