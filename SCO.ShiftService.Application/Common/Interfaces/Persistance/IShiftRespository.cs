using SCO.ShiftService.Domain.Entities;

namespace SCO.ShiftService.Application.Common.Interfaces.Persistance;
public interface IShiftRepository : IRepository<Shift>
{
    Task<Shift> GetActualShiftInfo();

    Task<Guid> GetActualShiftId();
}
