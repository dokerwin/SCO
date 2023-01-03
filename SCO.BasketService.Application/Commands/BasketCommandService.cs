using AutoMapper;
using SCO.BasketService.Domain;
using SCO.Contracts.DTOs;
using Item = SCO.BasketService.Domain.Entities.Item;

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

    public void AddItemToBasket(ItemDto itemDto)
    {
        var item = _mapper.Map<Item>(itemDto);
        _basketLogic.AddItemToBasket(item);
    }


    public void CalculatePromo(Guid itemDtoId)
    {
        
    }

    public void DeletItemFromBasket(Guid itemId)
    {
        _basketLogic.RemoveItemFromBasket(itemId);
    }
}
