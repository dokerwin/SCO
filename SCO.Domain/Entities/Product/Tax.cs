using SCO.Domain.Entities.Base;

namespace SCO.Domain.Entities.Product;

public class Tax : EntityBase<Guid>
{
    public string Name;

    public decimal Percent;
}

