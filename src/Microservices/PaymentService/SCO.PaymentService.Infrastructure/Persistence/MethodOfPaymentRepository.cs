using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SCO.PaymentService.Application.Common.Interfaces.Persistance;
using SCO.PaymentService.Domain.Enteties;
using SCO.PaymentService.EntityFramework.Persistence;
using SCO.PaymentService.Infrastructure.Persitence;

namespace SCO.PaymentService.Infrastructure.Persistence;

public class MethodOfPaymentRepository : Repository<MethodOfPayment>, IMethodOfPaymentRepository
{
    public MethodOfPaymentRepository(SCOPaymentContext context, ILogger<MethodOfPaymentRepository> logger)
        : base(context, logger)
    {
    }
}
