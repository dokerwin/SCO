using SCO.Domain.Entities.Base;
using SCO.Domain.Entities.Employees;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SCO.Domain.Entities.Customers;

public class Customer : EntityBase<Guid>
{
    [EmailAddress]
    public string Email { get; set; }
    public string Firstname { get; set; }
    public string LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string PasswordHash { get; set; }
    public Guid RoleId { get; set; }

    [ForeignKey(nameof(RoleId))]
    public virtual Role Role { get; set; }
}
