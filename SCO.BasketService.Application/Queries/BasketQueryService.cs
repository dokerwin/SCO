using AutoMapper;
using SCO.BasketService.Domain;
using SCO.Contracts.DTOs;

namespace SCO.BasketService.Application.Queries;

public class BasketQueryService : IBasketQueryService
{
    private readonly IBasketLogic _basketLogic;
    private readonly IMapper _mapper;

    public BasketQueryService(IBasketLogic basketLogic, IMapper mapper)
    {
        _basketLogic = basketLogic;
        _mapper = mapper;
    } 

    public IEnumerable<ItemDto> GetAllProducts()
    {
        var itemsInOrder = _basketLogic.GetActualOrder().Items;

        var productDtos = _mapper.Map<IEnumerable<ItemDto>>(itemsInOrder);

        return productDtos;
    }

    public decimal GetBasketPrice()
    {
       return _basketLogic.GetBasketPrice();
    }
}
