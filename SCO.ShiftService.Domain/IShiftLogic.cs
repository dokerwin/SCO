namespace SCO.ShiftService.Domain;

public interface IShiftLogic
{
    Task EndShift();
    Task StartShift(Guid cashierId);
}
