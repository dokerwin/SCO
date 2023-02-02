using AutoMapper;
using MassTransit;
using MediatR;
using SCO.Contracts.Requests.Payment;
using SCO.Contracts.Requests.Printer;
using SCO.Contracts.Responses.Printer;

namespace SCO.PrinterService.Application.MassTransit;

public class PrintTicketConsumer : IConsumer<PrintTicketRequest>
{

    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public PrintTicketConsumer(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task Consume(ConsumeContext<PrintTicketRequest> context)
    {
        var result = await _mediator.Send(new PrintTicketCommand(context.Message.TicketDto));
        await context.RespondAsync(result);
    }
}
