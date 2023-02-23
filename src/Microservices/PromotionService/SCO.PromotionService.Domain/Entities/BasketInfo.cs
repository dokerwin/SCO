using SCO.PromotionService.Domain.Enums;

namespace SCO.PromotionService.Domain.Entities;

public class BasketInfo
{
    public PromotionType PromotionType { get; set; }
    public decimal PromoValue { get; set; }
}
