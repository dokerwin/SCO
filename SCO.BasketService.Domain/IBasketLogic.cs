using SCO.BasketService.Domain.Entities;

namespace SCO.BasketService.Domain;

public interface IBasketLogic
{   
    decimal GetBasketPrice();
    void AddItemToBasket(Item item);
    void RemoveItemFromBasket(Guid item);
    Order GetActualOrder();
    void OpenOrder();
    void AbortOrder();
    void CloseOrder();
}