using SCO.Identity.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCO.Identity.Domain.Entities.Employees;
public class Cashier : EntityBase<Guid>
{
    [EmailAddress]
    public string Email { get; set; }
    public string Firstname { get; set; }
    public string LastName { get; set; }
    public string PasswordHash { get; set; }
    public Guid RoleId { get; set; }

    [ForeignKey(nameof(RoleId))]
    public virtual Role Role { get; set; }
}