using AutoMapper;
using MassTransit;
using SCO.BasketService.Application.Common.Interfaces.Persistance;
using SCO.Contracts.Requests.Order;
using SCO.Contracts.DTOs;
using SCO.Contracts.Responses;


namespace SCO.BasketService.Application.MassTransit;

public class AddItemToBasketConsumer : IConsumer<AddItemOrderRequest>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AddItemToBasketConsumer(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        //_basketLogic = basketLogic;
    }

    /// <summary>
    /// TODO: Refactor exception
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task Consume(ConsumeContext<AddItemOrderRequest> context)
    {
        try
        {
            //_basketLogic.AddItemToBasket(context.Message.Item);

            await context.RespondAsync(new AddItemOrderResponse());
        }
        catch (Exception ex)
        {

        }
    }
}
