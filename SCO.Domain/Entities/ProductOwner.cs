using SCO.Domain.Entities.Base;

namespace SCO.Domain.Entities;

public class ProductOwner : EntityBase<Guid>
{
    public string Name { get; set; }
    public int Type { get; set; }
}

