using Microsoft.Extensions.Logging;
using SCO.PaymentService.EntityFramework.Persistence;
using SCO.PaymentService.Application.Common.Interfaces.Persistance;

namespace SCO.PaymentService.Infrastructure.Persitence;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly SCOPaymentContext _context;
    private readonly ILogger<UnitOfWork> _logger;
    public IPaymentRepository Payments { get; private set; }

    public UnitOfWork(ILogger<UnitOfWork> logger,
        SCOPaymentContext context,
        IPaymentRepository paymentrRepository)
    {
        _logger = logger;
        _context = context;
        Payments = paymentrRepository;
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
