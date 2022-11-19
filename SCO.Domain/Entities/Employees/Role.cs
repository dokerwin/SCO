using SCO.Domain.Entities.Base;

namespace SCO.Domain.Entities.Employees;
public class Role : EntityBase<Guid>
{
    public string Name { get; set; }
}