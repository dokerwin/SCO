using MediatR;
using SCO.PaymentService.Application.Commands;
using SCO.PaymentService.Application.Common.Interfaces.Persistance;
using SCO.PaymentService.Application.DTOs;
using SCO.PaymentService.Application.Queries;
using SCO.PaymentService.Domain;

namespace SCO.PaymentService.Application.Handlers;

public class StartPaymentHandler : IRequestHandler<StartPaymentCommand, PaymentResultDto>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IPaymentLogic paymentLogic;
    private readonly IMediator mediator;

    public StartPaymentHandler(IUnitOfWork unitOfWork, IPaymentLogic paymentLogic, IMediator mediator)
    {
        this.unitOfWork = unitOfWork;
        this.paymentLogic = paymentLogic;
        this.mediator = mediator;
    }
    public async Task<PaymentResultDto> Handle(StartPaymentCommand request, CancellationToken cancellationToken)
    {

        var paymentAmount = await mediator.Send(new GetPaymentAmountQuery(request.Items));


        var result = await paymentLogic.ProcessPayment(request.OrderID, paymentAmount.Amount);

        if (result is not null)
        {
        
        }

        return await Task.FromResult(new PaymentResultDto());
    }
}
