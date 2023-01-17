using AutoMapper;
using MediatR;
using SCO.BasketService.Application.Queries;
using SCO.BasketService.Domain;
using SCO.Contracts.DTOs;
using SCO.Contracts.Responses.Basket;

namespace SCO.BasketService.Application.Handlers;

public class GetBasketDetailsQueryHandler : IRequestHandler<GetBasketDetailsQuery, BasketDetailsResponse>
{
    private readonly IBasketLogic _basketLogic;
    private readonly IMapper _mapper;

    public GetBasketDetailsQueryHandler(IBasketLogic basketLogic, IMapper mapper)
    {
        _basketLogic = basketLogic;
        _mapper = mapper;
    }

    public Task<BasketDetailsResponse> Handle(GetBasketDetailsQuery request, CancellationToken cancellationToken)
    {
        var order = _basketLogic.GetActualOrder();

        var itemsDto = _mapper.Map<IEnumerable<BasketItemDetailDto>>(order.Items);

        return Task.FromResult(new BasketDetailsResponse()
        {
            BasketDetails = new BasketDto()
            {
                ItemDetails = itemsDto,
                OrderId = order.Id,
                OrderedOn = order.OrderedOn
            }
        });
    }
}
