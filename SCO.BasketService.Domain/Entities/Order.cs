using SCO.BasketService.Domain.Entities.Base;
using SCO.BasketService.Domain.Enums;

namespace SCO.BasketService.Domain.Entities;

public class Order : EntityBase<Guid>
{
    public readonly List<Item> _items;

    public Order()
    {
        Id = Guid.NewGuid();
        _items = new List<Item>();
    }

    public IEnumerable<Item> Items
    {
        get { return _items; }
    }

    public void AddItem(Item item)
    {
        _items.Add(item);
    }

    public void DeleteItem(Guid itemId)
    {
        _items.RemoveAll(s=>s.Id == itemId);
    }
    public void CloseOrder()
    {
        OrderedOn = DateTime.Now;
    }

    public DateTime OrderedOn { get; internal set; }
    public Guid PaymentId { get; set; }
    public Guid ShiftId { get; set; }
    public OrderStatus OrderStatus { get; set; }
}
