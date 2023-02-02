using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using SCO.Contracts.Requests.Order;
using SCO.Contracts.Responses.Basket;
using SCO.PaymentService.Application.Commands;
using SCO.PaymentService.Application.Common.Interfaces.Persistance;
using SCO.PaymentService.Application.DTOs;
using SCO.PaymentService.Application.Queries;
using SCO.PaymentService.Domain;
using SCO.PaymentService.Domain.Enteties;
using SCO.PaymentService.Domain.Enums;

namespace SCO.PaymentService.Application.Handlers;

public class StartPaymentHandler : IRequestHandler<StartPaymentCommand, PaymentResultDto>
{
    private readonly ILogger<StartPaymentHandler> _logger;
    private readonly IBusControl _busControl;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPaymentLogic _paymentLogic;
    private readonly IMediator _mediator;

    public StartPaymentHandler(IBusControl busControl,
        IUnitOfWork unitOfWork,
        IPaymentLogic paymentLogic,
        IMediator mediator,
        ILogger<StartPaymentHandler> logger)
    {
        _busControl = busControl;
        _unitOfWork = unitOfWork;
        _paymentLogic = paymentLogic;
        _mediator = mediator;
        _logger = logger;
    }
    public async Task<PaymentResultDto> Handle(StartPaymentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var _productClient = _busControl.CreateRequestClient<BasketRequest>(TimeSpan.FromSeconds(180));
            var itemsInOrder = await _productClient.GetResponse<BasketDetailsResponse>(
                 new BasketRequest(request.OrderID));

            var paymentAmount = await _mediator.Send(new GetPaymentAmountQuery(itemsInOrder.Message.BasketDetails.ItemDetails));

            if (paymentAmount != null)
            {
                var result = await _paymentLogic.ProcessPayment(request.OrderID, (decimal)paymentAmount.Amount);


                Payment payment = new();

                payment.SetStatus((PaymentStatus)result.Result);
                payment.SetOrderId(request.OrderID);

                await _unitOfWork.Payments.Add(payment);

                return await Task.FromResult(new PaymentResultDto() { 
                    PaymentId = result.PaymentId,
                    Status = result.Result
                });
            }

        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }

        return await Task.FromResult(new PaymentResultDto());
    }
}
