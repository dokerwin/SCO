using SCO.PromotionService.EntityFramework.Persistence;

namespace SCO.PromotionService.EntityFramework.Seed;
public class SCOPromotionServiceDbInitializer
{
    public static void Initialize(SCOPromotionServiceContext _dbContext)
    {
        if (_dbContext.Database.CanConnect())
        {
            if (!_dbContext.Promotions.Any())
            {
                _dbContext.Promotions.AddRange(PromotionSeeder.GetPromotions());
                _dbContext.SaveChanges();
            }
        }
    }
}
