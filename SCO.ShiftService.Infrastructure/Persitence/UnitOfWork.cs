using SCO.ShiftService.Application.Common.Interfaces.Persistance;
using SCO.ShiftService.EntityFramework.Persistence;

namespace SCO.ShiftService.Infrastructure.Persitence;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly SCOShiftContext _context;
    public IShiftRepository Shifts { get; private set; }
  

    public UnitOfWork(SCOShiftContext context,
        IShiftRepository shiftRepository)
       
    {
        _context = context;
        Shifts = shiftRepository;
    }

    public async Task CompleteAsync()
    {
        try 
        { 
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("dffdf");   
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
