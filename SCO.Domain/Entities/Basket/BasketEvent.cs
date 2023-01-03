using SCO.Domain.Entities.Product;

namespace SCO.Domain.Entities;

public class BasketEvent : EventBase
{ 
    public CartEventTypeEnum Type { get; set; }
    public Item Item { get; set; }
}
