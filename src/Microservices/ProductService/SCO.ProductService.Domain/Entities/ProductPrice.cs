using SCO.ProductService.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;

namespace SCO.ProductService.Domain.Entities;

public class ProductPrice : EntityBase<Guid>
{
    public string Currency { get; set; }
    public decimal Price { get; set; }
    public Guid ProductId { get; set; }

    [ForeignKey(nameof(ProductId))]
    public virtual Product Product { get; set; }
}

