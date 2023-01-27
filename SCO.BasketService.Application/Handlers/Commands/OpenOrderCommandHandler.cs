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
using SCO.Contracts.Requests.Shift;
using SCO.Contracts.Responses.Shift;

namespace SCO.BasketService.Application.Handlers.Commands;

public class OpenOrderCommandHandler : IRequestHandler<OpenOrderCommand, OpenOrderResponse>
{
    private readonly IBusControl _busControl;
    private readonly IMapper _mapper;
    private readonly IBasketLogic _basketLogic;
    private readonly ILogger<OpenOrderCommandHandler> _logger;

    public OpenOrderCommandHandler(IMapper mapper, IBasketLogic basketLogic, ILogger<OpenOrderCommandHandler> logger, IBusControl busControl = null)
    {
        _mapper = mapper;
        _basketLogic = basketLogic;
        _logger = logger;
        _busControl = busControl;
    }

    public async  Task<OpenOrderResponse> Handle(OpenOrderCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (_basketLogic.GetOrderStatus() == Domain.Enums.OrderStatus.Open)
            {
                var _productClient = _busControl.CreateRequestClient<ActualShiftInfoRequest>(TimeSpan.FromSeconds(180));

                var shiftInfo = await _productClient.GetResponse<ActualShiftInfoResponse>(
                     new ActualShiftInfoRequest());

                if (shiftInfo != null)
                {
                    _basketLogic.SetShift(shiftInfo.Message.ShiftInfoDto.Id);
                    return await Task.FromResult(new OpenOrderResponse() { Status = true });
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }

        return await Task.FromResult(new OpenOrderResponse() { Status = false });
    }
}
