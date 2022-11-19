using SCO.Domain.Entities.Base;

namespace SCO.Domain.Entities;

public class Category : EntityBase<Guid>
{
    public int GategoryIdentifire { get; set; }
    public string Name { get; set; }
}

