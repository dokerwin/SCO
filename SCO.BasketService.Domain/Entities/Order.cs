using SCO.BasketService.Domain.Entities.Base;

namespace SCO.BasketService.Domain.Entities;

public class Order : EntityBase<Guid>
{
    public List<Item> Items { get; internal set; }
	
    public Guid PaymentId { get; internal set; }
}
