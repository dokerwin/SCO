using SCO.Domain.Entities;
using SCO.EntityFramework.Persistence;


namespace SCO.EntityFramework.Seed;
public class SCODbInitializer
{
    public static void Initialize(SCOContext _dbContext)
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
