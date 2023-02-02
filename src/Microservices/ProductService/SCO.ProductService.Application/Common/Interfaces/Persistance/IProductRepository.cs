using SCO.ProductService.Domain.Entities;

namespace SCO.ProductService.Application.Common.Interfaces.Persistance;

public interface IProductRepository : IRepository<Product> 
{
    IEnumerable<Product> GetTopSellingProducts(int count);
}

