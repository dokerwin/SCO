using Microsoft.Extensions.Logging;
using SCO.ProductService.Application.Common.Interfaces.Persistance;
using SCO.ProductService.EntityFramework.Persistence;

namespace SCO.ProductService.Infrastructure.Persitence;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly SCOProductContext _context;
    private readonly ILogger _logger;

    public IProductOwnerRepository ProductOwners { get; private set; }
    public IProductRepository Products { get; private set; }
    public ITaxRepository Taxes { get; private set; }
    public IVatRepository Vats { get; private set; }

    public ICategoryRepository Categories { get; private set; }

    public ITaxRepository Taxs { get; private set; }

    public UnitOfWork(SCOProductContext context,
        ILoggerFactory loggerFactory,
        IProductOwnerRepository productOwnerRepository,
        IProductRepository productRepository,
        ITaxRepository taxRepository,
        IVatRepository vatRepository
        )
    {
        _context = context;
        _logger = loggerFactory.CreateLogger("logs");
        Products = productRepository;
        ProductOwners = productOwnerRepository;
        Taxes = taxRepository;
        Vats = vatRepository;
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
