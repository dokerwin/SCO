using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SCO.PaymentService.Application.Common.Interfaces.Persistance;
using SCO.PaymentService.Domain.Enteties;
using SCO.PaymentService.Infrastructure.Persitence;

namespace SCO.PaymentService.Infrastructure.Persistence;

public class MethodOfPaymentRepository : Repository<MethodOfPayment>, IMethodOfPaymentRepository
{
    public MethodOfPaymentRepository(DbContext context, ILogger<MethodOfPaymentRepository> logger)
        : base(context, logger)
    {
    }


}
