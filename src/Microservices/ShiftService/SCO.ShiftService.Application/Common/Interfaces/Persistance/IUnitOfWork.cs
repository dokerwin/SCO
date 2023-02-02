namespace SCO.ShiftService.Application.Common.Interfaces.Persistance;

public interface IUnitOfWork : IDisposable
{
    IShiftRepository Shifts { get; }

    Task CompleteAsync();
}

