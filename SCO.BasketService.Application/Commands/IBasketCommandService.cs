
using SCO.Contracts.DTOs;

namespace SCO.BasketService.Application.Commands;
public interface IBasketCommandService
{
    void AddItemToBasket(ItemDto itemDtoId);
    void DeletItemFromBasket(Guid itemDtoId);
    void CalculatePromo(Guid itemDtoId);

}
