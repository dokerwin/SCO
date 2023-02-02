using Microsoft.Extensions.Logging;
using SCO.BasketService.Domain;
using SCO.BasketService.Domain.Entities;
using SCO.BasketService.Domain.Enums;

namespace SCO.BasketService.Application;

public class BasketLogic : IBasketLogic
{
    private Order _order;
 
    private readonly ILogger<BasketLogic> _logger;

    public BasketLogic(ILogger<BasketLogic> logger)
    {
        _order = new Order();
        _logger = logger;
    }

    public void AbortOrder()
    {
        _order.OrderStatus = OrderStatus.Closed;
        _order = new Order();
    }

    public void AddItemToBasket(Item item)
    {
        _order.AddItem(item);
    }

    public async Task CloseOrder()
    {
        try
        {
            _order.OrderStatus = OrderStatus.Closed;
            _order.CloseOrder();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
    }

    public Order GetActualOrder()
    {
        return _order;
    }

    public decimal GetBasketPrice()
    {
       return _order.Items.Sum(x => x.Price);
    }

    public OrderStatus GetOrderStatus()
    {
        return _order.OrderStatus;
    }



    public void OpenOrder()
    {
        _order = new Order();
        _order.OrderStatus = OrderStatus.Open; 
    }

    public void RemoveItemFromBasket(Guid itemId)
    {
        _order.DeleteItem(itemId);
    }

    public void SetPayment(Guid paymentId)
    {
        _order.PaymentId = paymentId;
    }

    public void SetShift(Guid shiftId)
    {
        _order.ShiftId = shiftId;
    }
}
