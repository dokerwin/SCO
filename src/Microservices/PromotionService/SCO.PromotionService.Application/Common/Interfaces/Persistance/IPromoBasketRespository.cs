using SCO.PromotionService.Domain;
using SCO.PromotionService.Domain.Entities;

namespace SCO.PromotionService.Application.Common.Interfaces.Persistance;
public interface IPromoBasketRepository : IRepository<PromoBasket>
{
    Task<IEnumerable<PromoBasket>> FindMatchedBaskets(RawBasket rawBaskets);
}
