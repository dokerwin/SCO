using SCO.Domain.Entities.Base;

namespace SCO.Domain.Entities.Product;

public class Vat : EntityBase<Guid>
{
    public string Name { get; set; }
    public decimal Percent { get; set; }
}

