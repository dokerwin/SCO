using SCO.BasketService.Domain.Entities;

namespace SCO.BasketService.Domain;

public class BasketLogic : IBasketLogic
{
    private Order _order;
	public BasketLogic()
	{
        _order = new Order();
    }

    public void AbortOrder()
    {
        _order.OrderStatus = (int)Enums.OrderStatus.Closed;
        _order = new Order();
    }

    public void AddItemToBasket(Item item)
    {
        _order.AddItem(item);
    }

    public void CloseOrder()
    {
        _order.OrderStatus = (int)Enums.OrderStatus.Closed;
        _order = new Order();
    }

    public Order GetActualOrder()
    {
        return _order;
    }

    public decimal GetBasketPrice()
    {
       return _order.Items.Sum(x => x.Price);
    }

    public void OpenOrder()
    {
        _order = new Order();
        _order.OrderStatus = (int)Enums.OrderStatus.Open;
    }

    public void RemoveItemFromBasket(Guid itemId)
    {
        _order.DeleteItem(itemId);
    }
}
