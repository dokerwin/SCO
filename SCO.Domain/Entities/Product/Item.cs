using SCO.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCO.Domain.Entities.Product;

public class Item : EntityBase<Guid>
{
    public string Barcode { get; set; }
    public string Name { get; set; }
    public string ShortName { get; set; }

    public decimal Price { get; set; }
    public Guid TaxId { get; set; }

    [ForeignKey(nameof(TaxId))]
    public virtual Tax? Tax { get; set; }
    public Guid VatId { get; set; }

    [ForeignKey(nameof(VatId))]
    public virtual Vat? Vat { get; set; }
    public Guid ProductOwnerId { get; set; }

    [ForeignKey(nameof(ProductOwnerId))]
    public virtual ProductOwner? ProductOwner { get; set; }
    public object Quantity { get; set; }
}

