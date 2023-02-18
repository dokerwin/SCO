using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SCO.PromotionService.Application.Common.Interfaces.Persistance;
using SCO.PromotionService.Domain.Entities;
using SCO.PromotionService.Domain.ValueObjects;
using SCO.PromotionService.EntityFramework.Persistence;

namespace SCO.PromotionService.Infrastructure.Persitence;

public class PromoBasketRepository : EFRepository<PromoBasket>, IPromoBasketRepository
{
    public PromoBasketRepository(SCOPromotionServiceContext context,
        ILogger<PromoBasketRepository> logger) : base(context, logger)
    {
    }

    public async Task<IEnumerable<PromoBasket>> FindMatchedBaskets(RawBasket rawBasket)
    {
        var matchedPromoBaskets = new List<PromoBasket>();

        var _promoBaskets = await _dbSet.ToListAsync();

        var result = new List<PromoBasket>();

        foreach (var rawItem in rawBasket.Items)
        {
            foreach (var promoBasket in _promoBaskets)
            {
                if (promoBasket.Items.Any(item => item.Id == rawItem.Id))
                {
                    result.Add(promoBasket);
                }
            }
        }

        return result;
    }
}
