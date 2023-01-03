using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SCO.Application.Common.Interfaces.Persistance;
using SCO.Domain.Entities;
using SCO.EntityFramework.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCO.Infrastructure.Persitence;

public class ShiftRepository : Repository<Shift>, IShiftRepository
{
    private readonly SCOContext context;
    private readonly ILogger<ShiftRepository> logger;

    public ShiftRepository(SCOContext context, ILogger<ShiftRepository> logger) : base(context, logger)
    {
        this.context = context;
        this.logger = logger;
    }

    public async Task<Shift> GetActualShift()
    {
        try
        {
            var actualShift = await _dbSet.LastOrDefaultAsync();
            if (actualShift is not null)
                return actualShift;

            return new Shift();

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Repo} Upsert function error", typeof(ShiftRepository));
            return new Shift();
        }
    }

    public override async Task<bool> Upsert(Shift entity)
    {
        try
        {
            var existingRole = await _dbSet.Where(x => x.Id == entity.Id)
                                              .FirstOrDefaultAsync();
            if (existingRole == null)
                return await Add(entity);

            existingRole.CashierId = entity.CashierId;


            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Repo} Upsert function error", typeof(ShiftRepository));
            return false;
        }
    }
}

