using AutoMapper;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using SCO.BasketService.Application.Commands;
using SCO.BasketService.Domain;
using SCO.BasketService.Domain.Entities;
using SCO.Contracts.Requests.Product;
using SCO.Contracts.Responses.Basket;
using SCO.Contracts.Responses;
using SCO.Contracts.Requests.Payment;
using SCO.Contracts.Responses.Payment;
using SCO.BasketService.Application.Common.Interfaces.Persistance;

namespace SCO.BasketService.Application.Handlers.Commands;

public class FinishOrderCommandHandler : IRequestHandler<FinishOrderCommand, FinishOrderResponse>
{

    private readonly IMapper _mapper;
    private readonly IBasketLogic _basketLogic;
    private readonly ILogger<FinishOrderCommandHandler> _logger;
    private readonly IBusControl _busControl;
    private readonly IUnitOfWork _unitOfWork;

    public FinishOrderCommandHandler(IMapper mapper, IBasketLogic basketLogic, ILogger<FinishOrderCommandHandler> logger, IBusControl busControl = null, IUnitOfWork unitOfWork = null)
    {
        _mapper = mapper;
        _basketLogic = basketLogic;
        _logger = logger;
        _busControl = busControl;
        _unitOfWork = unitOfWork;
    }

    public async Task<FinishOrderResponse> Handle(FinishOrderCommand request, CancellationToken cancellationToken)
    {

        try
        {
            if (_basketLogic.GetOrderStatus() == Domain.Enums.OrderStatus.Open)
            {
                var _paymentClient = _busControl.CreateRequestClient<PaymentRequest>(TimeSpan.FromSeconds(180));

                var paymentResponse = await _paymentClient.GetResponse<PaymentResponse>(
                     new PaymentRequest(_basketLogic.GetActualOrder().Id));

                if (paymentResponse != null && paymentResponse.Message.PaymentStatus == 0 )
                {
                    _basketLogic.SetPayment(paymentResponse.Message.PaymentId);
                    await _unitOfWork.Orders.Add(_basketLogic.GetActualOrder());
                    await _unitOfWork.CompleteAsync();
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }

        return await Task.FromResult(new FinishOrderResponse());
    }
}
