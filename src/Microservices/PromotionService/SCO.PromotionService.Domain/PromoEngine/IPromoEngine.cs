using SCO.PromotionService.Domain.ValueObjects;

namespace SCO.PromotionService.Domain.PromoEngine;

public interface IPromoEngine
{
    CalculatedBasket CalculatePromotion(RawBasket rawBasket);
}