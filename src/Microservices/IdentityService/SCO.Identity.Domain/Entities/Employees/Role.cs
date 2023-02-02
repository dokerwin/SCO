using SCO.Identity.Domain.Entities.Base;

namespace SCO.Identity.Domain.Entities.Employees;
public class Role : EntityBase<Guid>
{
    public string Name { get; set; }
}