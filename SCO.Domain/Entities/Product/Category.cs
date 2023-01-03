using SCO.Domain.Entities.Base;

namespace SCO.Domain.Entities.Product;

public class Category : EntityBase<Guid>
{
    public int GategoryIdentifire { get; set; }
    public string Name { get; set; }
}

