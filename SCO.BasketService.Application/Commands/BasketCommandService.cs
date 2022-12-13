using AutoMapper;
using SCO.BasketService.Domain;
using SCO.Interfaces;

namespace SCO.BasketService.Application.Commands;

public class BasketCommandService : IBasketCommandService
{
    private readonly IMapper _mapper;
    private readonly IBasketLogic _basketLogic;

    public BasketCommandService(IMapper mapper, IBasketLogic basketLogic)
    {
        _mapper = mapper;
        _basketLogic = basketLogic;
    }

    public void AddItemToBasket(Guid itemDtoId)
    {
        _basketLogic.AddItemToBasket(itemDtoId);
    }

    public void CalculatePromo(Guid itemDtoId)
    {
        
    }

    public void DeletItemFromBasket(Guid itemDtoId)
    {
        
    }
}
