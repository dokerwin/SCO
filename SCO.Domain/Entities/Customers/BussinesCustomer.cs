using SCO.Domain.Entities.Base;
using SCO.Domain.Entities.Company;

namespace SCO.Domain.Entities.Customers;
public class BussinesCustomer : EntityBase<Guid>
{
    public Guid CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public Guid CompanyId { get; set; }
    public CustomerCompany? CustomerCompany { get; set; }
}
