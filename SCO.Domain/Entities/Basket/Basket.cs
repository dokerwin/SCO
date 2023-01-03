using SCO.Domain.Entities.Product;

namespace SCO.Domain.Entities;

public class Basket
{
    public IEnumerable<Item> Items { get; set; }
}
