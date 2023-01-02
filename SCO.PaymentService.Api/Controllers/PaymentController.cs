using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCO.Contracts.DTOs;
using SCO.PaymentService.Application.Commands;
using SCO.PaymentService.Application.DTOs;
using SCO.PaymentService.Application.Queries;

namespace SCO.PaymentService.Conrollers;
[ApiController]
[Route("payment")]
public class PaymentController : ControllerBase
{
    private readonly IMediator _mediator;

    public PaymentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public ActionResult<PaymentDto> Get([FromRoute] Guid id)
    {
        var payment = _mediator.Send(new GetPaymentByIdQuery(id));

        return Ok(payment);
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<Guid> CreatePayment([FromBody] Guid id, [FromBody] IEnumerable<ItemDto> ItemsDto)
    {
        var result = await _mediator.Send(new StartPaymentCommand(id,ItemsDto));
        return result.PaymentId;
    }
}