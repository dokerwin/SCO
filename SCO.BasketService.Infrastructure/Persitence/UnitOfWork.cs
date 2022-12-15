using Microsoft.Extensions.Logging;
using SCO.BasketService.Application.Common.Interfaces.Persistance;
using SCO.BasketService.EntityFramework.Persistence;


namespace SCO.BaskerService.Infrastructure.Persitence;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly SCOBasketServiceContext _context;
    private readonly ILogger<UnitOfWork> _logger;

   
    public IOrderRepository Orders { get; private set; }
   
    public UnitOfWork(SCOBasketServiceContext context,
        ILogger<UnitOfWork> loggerFactory, IOrderRepository orderRepository
       
        )
    {
        _context = context;
        _logger = loggerFactory;
        Orders = orderRepository;
        
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
