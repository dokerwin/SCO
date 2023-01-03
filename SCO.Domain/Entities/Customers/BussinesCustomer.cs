using SCO.Domain.Entities.Base;
using SCO.Domain.Entities.Company;
using SCO.Domain.Entities.Employees;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCO.Domain.Entities.Customers;
public class BussinesCustomer : EntityBase<Guid>
{
    public Guid CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public Guid CompanyId { get; set; }

    [ForeignKey(nameof(CompanyId))]
    public CustomerCompany? CustomerCompany { get; set; }
}
