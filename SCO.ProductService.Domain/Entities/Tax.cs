using SCO.ProductService.Domain.Entities.Base;

namespace SCO.ProductService.Domain.Entities;

public class Tax : EntityBase<Guid>
{
    public string Name;

    public decimal Percent;
}

