using Microsoft.AspNetCore.Components;
using SCO.Application.DTOs;
using SCO.Domain.Entities.Product;


namespace MicroCommerce
{
    public interface IProductCatalog
    {
        IEnumerable<Item> Get();

        public Item Get(Guid productId);
    }
}
