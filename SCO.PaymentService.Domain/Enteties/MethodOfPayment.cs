using SCO.PaymentService.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCO.PaymentService.Domain.Enteties
{
    public class MethodOfPayment : EntityBase<Guid>
    {
        public string Name { get; set; }
        public int DiscountRule { get; set; }
    }
}
