using SCO.PromotionService.Domain.Entities.Base;

namespace SCO.PromotionService.Domain.Entities;

public class Item 
{
    public Guid Id { get; set; }
    public string Barcode { get; set; }
    public decimal Qt { get; set; }
}
