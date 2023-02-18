using SCO.PromotionService.Domain.Entities.Base;
using SCO.PromotionService.Domain.Enums;

namespace SCO.PromotionService.Domain.Entities;

public class PromoBasket : EntityBase<Guid>
{
    public List<Item> Items { get; set; }
    public decimal PromotionValue { get; set; }
    public PromotionType PromotionType { get; set; }
   
}
