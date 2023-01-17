using MassTransit;
using MediatR;
using SCO.Contracts.Requests.Order;
using SCO.Contracts.Requests.Product;
using SCO.Contracts.Responses;
using SCO.Contracts.Responses.Basket;
using SCO.PaymentService.Application.Commands;
using SCO.PaymentService.Application.Common.Interfaces.Persistance;
using SCO.PaymentService.Application.DTOs;
using SCO.PaymentService.Application.Queries;
using SCO.PaymentService.Domain;

namespace SCO.PaymentService.Application.Handlers;

public class StartPaymentHandler : IRequestHandler<StartPaymentCommand, PaymentResultDto>
{
    private readonly IBusControl busControl;
    private readonly IUnitOfWork unitOfWork;
    private readonly IPaymentLogic paymentLogic;
    private readonly IMediator mediator;

    public StartPaymentHandler(IBusControl busControl, IUnitOfWork unitOfWork, IPaymentLogic paymentLogic, IMediator mediator)
    {
        this.busControl = busControl;
        this.unitOfWork = unitOfWork;
        this.paymentLogic = paymentLogic;
        this.mediator = mediator;
    }
    public async Task<PaymentResultDto> Handle(StartPaymentCommand request, CancellationToken cancellationToken)
    {
        var _productClient = busControl.CreateRequestClient<BasketRequest>(TimeSpan.FromSeconds(180));
        var itemsInOrder = await _productClient.GetResponse<BasketDetailsResponse>(
             new BasketRequest(request.OrderID));

        var paymentAmount = await mediator.Send(new GetPaymentAmountQuery(itemsInOrder.Message.BasketDetails.ItemDetails));

        var result = await paymentLogic.ProcessPayment(request.OrderID, paymentAmount.Amount);

        if (result is not null) { }

        return await Task.FromResult(new PaymentResultDto());
    }
}
