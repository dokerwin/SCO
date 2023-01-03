using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SCO.Identity.Application.Common.Interfaces.Persistance;
using SCO.Identity.Domain.Entities.Employees;
using SCO.Identity.EntityFramework.Persistence;

namespace SCO.Identity.Infrastructure.Persitence;

public class RoleRepository : Repository<Role>, IRoleRepository
{
    public RoleRepository(SCOIndentityContext context, ILogger logger) : base(context, logger) {}

    public override async Task<bool> Upsert(Role entity)
    {
        try
        {
            var existingRole= await _dbSet.Where(x => x.Id == entity.Id)
                                                .FirstOrDefaultAsync();
            if (existingRole == null)
                return await Add(entity);

            existingRole.Name = entity.Name;

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Repo} Upsert function error", typeof(RoleRepository));
            return false;
        }
    }
}

