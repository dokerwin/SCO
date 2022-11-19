using SCO.Domain.Entities.Base;
using SCO.Domain.Entities.Employees;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCO.Domain.Entities;
public class Shift : EntityBase<Guid>
{
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public Guid CashierId { get; set; }

    [ForeignKey(nameof(CashierId))]
    public virtual Cashier? Cashier { get; set; }

}
