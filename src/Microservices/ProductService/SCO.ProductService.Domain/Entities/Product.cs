using SCO.ProductService.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCO.ProductService.Domain.Entities;

public class Product : EntityBase<Guid>
{
    public string Barcode { get; set; }
    public string Name { get; set; }
    public string ShortName { get; set; }
    public double Price { get; set; }

    public Guid ProductTypeId { get; set; }

    [ForeignKey(nameof(ProductTypeId))]
    public virtual ProductType? ProductType { get; set; }

    public Guid CategoryId { get; set; }

    [ForeignKey(nameof(CategoryId))]
    public virtual Category? Category { get; set; }

    public Guid VatId { get; set; }

    [ForeignKey(nameof(VatId))]
    public virtual Vat? Vat { get; set; }

    public Guid ProductOwnerId { get; set; }

    [ForeignKey(nameof(ProductOwnerId))]
    public virtual ProductOwner? ProductOwner { get; set; }
}

