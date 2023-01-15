using AutoMapper;
using MassTransit;
using SCO.BasketService.Application.Common.Interfaces.Persistance;
using SCO.Contracts.Requests.Order;
using SCO.Contracts.DTOs;

namespace SCO.BasketService.Application.MassTransit;

public class OrderConsumer : IConsumer<BasketRequest>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public OrderConsumer(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
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
            var orderId = context.Message.BasketId;
            var orders = await _unitOfWork.Orders.Find(x => x.Id == orderId);
            var orderDtos = _mapper.Map<IEnumerable<ItemDto>>(orders);
            await context.RespondAsync(orderDtos);
        }
        catch (Exception ex)
        {
            
        }   
    }
}
