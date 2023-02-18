using SCO.PromotionService.Domain.Entities;
using SCO.PromotionService.Domain.ValueObjects;

namespace SCO.PromotionService.Application.Common.Interfaces.Persistance;
public interface IPromoBasketRepository : IRepository<PromoBasket>
{
    Task<IEnumerable<PromoBasket>> FindMatchedBaskets(RawBasket rawBaskets);
}
