
using SCO.Domain.Entities.Base;

namespace SCO.Domain.Entities;

public class Vat : EntityBase<Guid>
{
    public string Name { get; set; }
    public decimal Percent { get; set; }
}

