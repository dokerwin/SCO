using SCO.ShiftService.Domain.Entities.Base;

namespace SCO.ShiftService.Domain.Entities;
public class Shift : EntityBase<Guid>
{
    public DateTime StartedOn { get; set; }
    public DateTime? FinishedOn { get; set; }
    public Guid CashierId { get; set; }

}