using MediatR;
using SCO.BasketService.Application.Queries;
using SCO.BasketService.Domain;
using SCO.Contracts.Responses.Basket;

namespace SCO.BasketService.Application.Handlers.Queries;

public class GetBasketPriceQueryHandler : IRequestHandler<GetBasketPriceQuery, BasketPriceResponse>
{
    private readonly IBasketLogic _basketLogic;

    public GetBasketPriceQueryHandler(IBasketLogic basketLogic)
    {
        _basketLogic = basketLogic;
    }
    public async Task<BasketPriceResponse> Handle(GetBasketPriceQuery request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(new BasketPriceResponse()
        {
            BasketPrice = _basketLogic.GetBasketPrice()
        });
    }
}
