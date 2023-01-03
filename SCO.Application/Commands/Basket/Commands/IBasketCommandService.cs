using SCO.Contracts.DTOs;

namespace SCO.Application.Commands;

public interface IBasketCommandService
{
    void AddItemToBasket(ItemDto itemDto);
    void DeletItemFromBasket(Guid id);
}
