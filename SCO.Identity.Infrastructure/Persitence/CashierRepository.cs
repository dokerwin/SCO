using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SCO.Identity.Application.Common.Interfaces.Persistance;
using SCO.Identity.Domain.Entities.Employees;
using SCO.Identity.EntityFramework.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCO.Identity.Infrastructure.Persitence;

public class CashierRepository : Repository<Cashier>, ICashierRepository
{
    public CashierRepository(SCOIndentityContext context, ILogger logger) : base(context, logger) { }

    public override async Task<bool> Upsert(Cashier entity)
    {
        try
        {
            var existingCashier = await _dbSet.Where(x => x.Id == entity.Id)
                                                .FirstOrDefaultAsync();
            if (existingCashier == null)
                return await Add(entity);

            existingCashier.Firstname = entity.Firstname;
            existingCashier.LastName = entity.LastName;
            existingCashier.Email = entity.Email;
            existingCashier.PasswordHash = entity.PasswordHash;
            existingCashier.RoleId = entity.RoleId;
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Repo} Upsert function error", typeof(CashierRepository));
            return false;
        }
    }

    public async Task <Cashier> GetActualCashier()
    {
        try
        {
            var actualShift = await _dbSet.LastOrDefaultAsync();
            if (actualShift is not null)
                return actualShift;

            return new Cashier();

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Repo} Upsert function error", typeof(CashierRepository));
            return new Cashier();
        }
    }
}
