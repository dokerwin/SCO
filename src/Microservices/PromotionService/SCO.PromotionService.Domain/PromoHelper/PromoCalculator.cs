namespace SCO.PromotionService.Domain.PromoHelper;

public class PromoCalculator : IPromoCalculator
{
    public  decimal GetPromoValueAmount(decimal unitPrice, decimal quantitity, decimal promotionValue)
    {
        return (unitPrice - promotionValue / quantitity);
    }

    public  decimal GetPromoValuePercent(decimal unitPrice, decimal promotionValue)
    {
        return (unitPrice - unitPrice / 100 * promotionValue);
    }
}
