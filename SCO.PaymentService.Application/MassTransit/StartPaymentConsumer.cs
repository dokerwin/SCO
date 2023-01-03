using AutoMapper;
using MassTransit;
using MediatR;
using SCO.Contracts.Requests.Payment;
using SCO.Contracts.Responses;
using SCO.PaymentService.Application.Commands;
using SCO.PaymentService.Application.Common.Interfaces.Persistance;

namespace SCO.PaymentService.Application.MassTransit;

public class StartPaymentConsumer : IConsumer<PaymentRequest>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public StartPaymentConsumer(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _mediator = mediator;
    }

    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task Consume(ConsumeContext<PaymentRequest> context)
    {

        var result = await _mediator.Send(new StartPaymentCommand(context.Message.OrderId, context.Message.Items));
        await context.RespondAsync(result);
    }
}
