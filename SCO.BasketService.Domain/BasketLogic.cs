using SCO.BasketService.Domain.Entities;

namespace SCO.BasketService.Domain;

public class BasketLogic : IBasketLogic
{
    private Order _order;
	public BasketLogic()
	{
        _order = new Order();
    }

    public void AddItemToBasket(Guid item)
    {
        _order.Items.Add(new Item() { Id = item });
    }

    public void RemoveItemFromBasket(Guid itemId)
    {
        _order.Items.ForEach(x =>
        {
            if (x.Id == itemId)
                _order.Items.Remove(x);
        });
    }
}
