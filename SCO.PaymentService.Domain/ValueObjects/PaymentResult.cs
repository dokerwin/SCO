using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCO.PaymentService.Domain.ValueObjects;

public class PaymentResult
{
    public Guid PaymentId { get; set; }
    public int Result { get; set; }  
    
}
