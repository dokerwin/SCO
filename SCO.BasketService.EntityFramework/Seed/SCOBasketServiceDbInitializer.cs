using SCO.BasketService.EntityFramework.Persistence;

namespace SCO.BasketService.EntityFramework.Seed;
public class SCOBasketServiceDbInitializer
{
    public static void Initialize(SCOBasketServiceContext _dbContext)
    {
        if (_dbContext.Database.CanConnect())
        {
            if (!_dbContext.Orders.Any())
            {
                _dbContext.Orders.AddRange(OrderSeeder.GetRoles());
                _dbContext.SaveChanges();
            }
        }
    }
}
