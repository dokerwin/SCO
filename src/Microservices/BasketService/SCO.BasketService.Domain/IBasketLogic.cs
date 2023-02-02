using SCO.BasketService.Domain.Entities;
using SCO.BasketService.Domain.Enums;

namespace SCO.BasketService.Domain;

public interface IBasketLogic
{   
    decimal GetBasketPrice();
    void AddItemToBasket(Item item);
    void RemoveItemFromBasket(Guid item);
    Order GetActualOrder();
    void OpenOrder();
    void AbortOrder();
    Task CloseOrder();
    OrderStatus GetOrderStatus();
    void SetPayment(Guid paymentId);
    void SetShift(Guid shiftId);
}