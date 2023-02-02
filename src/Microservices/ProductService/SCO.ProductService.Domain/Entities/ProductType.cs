using SCO.ProductService.Domain.Entities.Base;

namespace SCO.ProductService.Domain.Entities;

public class ProductType : EntityBase<Guid>
{
    public string TypeName { get; set; }
}
