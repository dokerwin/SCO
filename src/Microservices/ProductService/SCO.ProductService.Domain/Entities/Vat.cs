using SCO.ProductService.Domain.Entities.Base;

namespace SCO.ProductService.Domain.Entities;

public class Vat : EntityBase<Guid>
{
    public string Name { get; set; }
    public decimal Percent { get; set; }
}

