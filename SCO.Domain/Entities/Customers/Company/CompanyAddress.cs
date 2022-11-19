using SCO.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCO.Domain.Entities.Customers.Company;

public class CompanyAddress : EntityBase<Guid>
{
    public string Country { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string Building { get; set; }
    public string PostalCode { get; set; }
}
