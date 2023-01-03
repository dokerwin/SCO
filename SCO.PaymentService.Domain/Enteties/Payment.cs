using SCO.PaymentService.Domain.Entities.Base;
using SCO.PaymentService.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace SCO.PaymentService.Domain.Enteties;

public class Payment : EntityBase<Guid>
{
    public DateTime PaymentDataTime { get; private set; }
    public decimal Amount { get; private set; }
    public int Status { get; private set; }
    public MethodOfPayment MethodOfPayment { get; private set; }

    public void SetAmount(decimal amount) 
    {
        Amount = amount;
    }
    public void SetMop(MethodOfPayment mop)
    {
        MethodOfPayment = mop;
    }


    public Payment()
    {
        PaymentDataTime = DateTime.Now;
    }

    public void SetStatus(PaymentStatus paymentStatus)
    {
        Status = (int)paymentStatus;
    }
}
