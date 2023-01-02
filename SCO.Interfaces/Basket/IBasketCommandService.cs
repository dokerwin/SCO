
using SCO.Contracts.DTOs;

namespace SCO.Interfaces;
public interface IBasketCommandService
{
    void AddItemToBasket(ItemDto itemDtoId);
    void DeletItemFromBasket(Guid itemDtoId);
    void CalculatePromo(Guid itemDtoId);

}
