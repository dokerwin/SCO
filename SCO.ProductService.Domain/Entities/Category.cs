using SCO.ProductService.Domain.Entities.Base;

namespace SCO.ProductService.Domain.Entities;

public class Category : EntityBase<Guid>
{
    public int GategoryIdentifire { get; set; }
    public string Name { get; set; }
}

