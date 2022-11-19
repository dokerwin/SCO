using SCO.Domain.Entities.Base;
using SCO.Domain.Entities.Customers.Company;

namespace SCO.Domain.Entities.Company;

public class CustomerCompany : EntityBase<Guid>
{
    public string Name { get; set; }
    public string TaxNumber { get; set; }
    public Guid CompanyAdressId { get; set; }
    public CompanyAddress? CompanyAddress { get; set; }
}
