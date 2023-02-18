using Microsoft.Extensions.Logging;
using SCO.PromotionService.Application.Common.Interfaces.Persistance;
using SCO.PromotionService.Domain.Entities;
using SCO.PromotionService.EntityFramework.Persistence;

namespace SCO.PromotionService.Infrastructure.Persitence;

public class PromotionRepository : Repository<Promotion>, IPromotionRepository
{
    public PromotionRepository(SCOPromotionServiceContext context, 
        ILogger<PromotionRepository> logger) : base(context, logger)
    {
    }
}

