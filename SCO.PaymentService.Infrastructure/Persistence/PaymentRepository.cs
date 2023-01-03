using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SCO.PaymentService.Application.Common.Interfaces.Persistance;
using SCO.PaymentService.Domain.Enteties;
using SCO.PaymentService.EntityFramework.Persistence;

namespace SCO.PaymentService.Infrastructure.Persitence;

public class PaymentRepository : Repository<Payment>, IPaymentRepository
{
    public PaymentRepository(SCOPaymentContext context, ILogger<PaymentRepository> logger) : base(context, logger) { }

    public override async Task<bool> Upsert(Payment entity)
    {
        try
        {
            var existingCategory = await _dbSet.Where(x => x.Id == entity.Id)
                                                .FirstOrDefaultAsync();
            if (existingCategory == null)
                return await Add(entity);


            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Repo} Upsert function error", typeof(PaymentRepository));
            return false;
        }
    }

}
