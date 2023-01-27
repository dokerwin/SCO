using AutoMapper;
using MassTransit;
using SCO.BasketService.Application.Common.Interfaces.Persistance;
using SCO.Contracts.Requests.Order;
using SCO.Contracts.DTOs;
using Microsoft.Extensions.Logging;
using SCO.BasketService.Application.Handlers.Commands;
using SCO.Contracts.Responses.Basket;
using SCO.BasketService.Domain;

namespace SCO.BasketService.Application.MassTransit;

public class OrderConsumer : IConsumer<BasketRequest>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<OrderConsumer> _logger;
    private readonly IBasketLogic _basketLogic;
    public OrderConsumer(IUnitOfWork unitOfWork, IMapper mapper, ILogger<OrderConsumer> logger, IBasketLogic basketLogic)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
        _basketLogic = basketLogic;
    }

    /// <summary>
    /// TODO: Refactor exception
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task Consume(ConsumeContext<BasketRequest> context)
    {
        try 
        {
            var order = _basketLogic.GetActualOrder();

            var itemsDto = _mapper.Map<IEnumerable<BasketItemDetailDto>>(order.Items);

            await context.RespondAsync(new BasketDetailsResponse()
            {
                BasketDetails = new BasketDto()
                {
                    ItemDetails = itemsDto,
                    OrderedOn = order.OrderedOn,
                    OrderId = order.Id
                }
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }   
    }
}
