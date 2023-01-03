using SCO.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;

namespace SCO.Domain.Entities.Product;

public class ProductPrice : EntityBase<Guid>
{
    public string Currency { get; set; }
    public decimal Price { get; set; }
    public Guid ProductId { get; set; }

    [ForeignKey(nameof(ProductId))]
    public virtual Item Product { get; set; }
}

