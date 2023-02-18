namespace SCO.PromotionService.Domain.PromoHelper;

public interface IPromoCalculator
{
    decimal GetPromoValueAmount(decimal unitPrice, decimal quantitity, decimal promotionValue);
    decimal GetPromoValuePercent(decimal unitPrice, decimal promotionValue);
}