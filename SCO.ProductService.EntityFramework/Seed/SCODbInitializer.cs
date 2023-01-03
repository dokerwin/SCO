using SCO.ProductService.EntityFramework.Persistence;

namespace SCO.ProductService.EntityFramework.Seed;
public class SCODbInitializer
{
    public static void Initialize(SCOProductContext _dbContext)
    {
        if (_dbContext.Database.CanConnect())
        {

            if (!_dbContext.ProductOwners.Any())
            {
                _dbContext.Vats.AddRange(ProductSeeder.GetVats());
                _dbContext.SaveChanges();
            }

            if (!_dbContext.Categories.Any())
            {
                _dbContext.Categories.AddRange(ProductSeeder.GetCategories());
                _dbContext.SaveChanges();
            }

            if (!_dbContext.ProductOwners.Any())
            {
                _dbContext.ProductOwners.AddRange(ProductSeeder.GetProductOwners());
                _dbContext.SaveChanges();
            }

            if (!_dbContext.ProductTypes.Any())
            {
                _dbContext.ProductTypes.AddRange(ProductSeeder.GetProductTypes());
                _dbContext.SaveChanges();
            }

            if (!_dbContext.Products.Any())
            {
                _dbContext.Products.AddRange(ProductSeeder.GetProducts());
                _dbContext.SaveChanges();
            }
        }
    }
}
