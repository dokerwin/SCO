using SCO.Domain.Entities.Base;

namespace SCO.Domain.Entities;

public class Tax : EntityBase<Guid>
{
    public string Name;

    public decimal Percent;
}

