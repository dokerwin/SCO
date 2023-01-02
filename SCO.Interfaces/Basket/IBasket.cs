using Microsoft.AspNetCore.Mvc;
using SCO.Domain.Entities;

namespace SCO.Interfaces;

public interface IBasket
{
    Basket Get();
    Basket AddItem(Guid productId, int qty);
    Basket DeleteOrder(Guid orderId);
    IEnumerable<BasketEvent> GetCartEvents(long timestamp);
}
