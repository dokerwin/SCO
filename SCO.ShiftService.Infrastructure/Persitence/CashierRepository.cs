using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SCO.ShiftService.Domain.Entities;
using SCO.ShiftService.Application.Common.Interfaces.Persistance;
using SCO.ShiftService.EntityFramework.Persistence;

namespace SCO.ShiftService.Infrastructure.Persitence;

public class ShiftRepository : Repository<Shift>, IShiftRepository
{
    public ShiftRepository(SCOShiftContext context, ILogger<ShiftRepository> logger) : base(context, logger) { }

    public async Task<Shift> GetActualShiftInfo()
    {
        try
        {
            var actualShift = await _dbSet.LastOrDefaultAsync();
            if (actualShift != null)
            {
                return await Task.FromResult(actualShift);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Repo} Upsert function error", typeof(ShiftRepository));
        }

        return await Task.FromResult(new Shift());
    }

    public async Task<Guid> GetActualShiftId()
    {
        try
        {
            var actualShift = await _dbSet.LastOrDefaultAsync();
            if (actualShift != null)
            {
                return await Task.FromResult(actualShift.Id);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Repo} Upsert function error", typeof(ShiftRepository));
        }

        return await Task.FromResult(Guid.Empty);
    }
}
