using SCO.ProductService.Domain.Entities.Base;

namespace SCO.ProductService.Domain.Entities;

public class Category : EntityBase<Guid>
{
    public string Name { get; set; }
}

