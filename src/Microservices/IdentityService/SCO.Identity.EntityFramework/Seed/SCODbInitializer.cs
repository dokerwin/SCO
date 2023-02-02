using SCO.Identity.Domain.Entities;
using SCO.Identity.EntityFramework.Persistence;


namespace SCO.Identity.EntityFramework.Seed;
public class SCODbInitializer
{
    public static void Initialize(SCOIndentityContext _dbContext)
    {
        if (_dbContext.Database.CanConnect())
        {
            if (!_dbContext.Roles.Any())
            {
                _dbContext.Roles.AddRange(RoleSeeder.GetRoles());
                _dbContext.SaveChanges();
            }
        }
    }
}
