using AutoMapper;
using MediatR;
using SCO.BasketService.Application.Queries;
using SCO.BasketService.Domain;
using SCO.Contracts.DTOs;
using SCO.Contracts.Responses.Basket;

namespace SCO.BasketService.Application.Handlers;

public class GetItemsInBasketQueryHandler : IRequestHandler<GetItemsInBasketQuery, ItemsInBasketResponse>
{
    private readonly IBasketLogic _basketLogic;
    private readonly IMapper _mapper;

    public GetItemsInBasketQueryHandler(IBasketLogic basketLogic, IMapper mapper)
    {
        _basketLogic = basketLogic;
        _mapper = mapper;
    }

    public Task<ItemsInBasketResponse> Handle(GetItemsInBasketQuery request, CancellationToken cancellationToken)
    {
        var order = _basketLogic.GetActualOrder();

        var itemsDto = _mapper.Map<IEnumerable<ItemDto>>(order.Items);

        return Task.FromResult(new ItemsInBasketResponse() { Items = itemsDto });
    }
}
