using SCO.ProductService.Domain.Entities.Base;

namespace SCO.ProductService.Domain.Entities;

public class ProductOwner : EntityBase<Guid>
{
    public string Name { get; set; }
    public int Type { get; set; }
}

