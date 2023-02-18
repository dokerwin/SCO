using Microsoft.Extensions.Logging;
using SCO.PromotionService.Application.Common.Interfaces.Persistance;
using SCO.PromotionService.EntityFramework.Persistence;

namespace SCO.PromotionService.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        // Instance of context for accessing the database
        private readonly SCOPromotionServiceContext _context;

        // Instance of logger for logging purposes
        private readonly ILogger<UnitOfWork> _logger;

        // Repository for handling promotions data
        public IPromotionRepository Promotions { get; private set; }

        // Repository for handling promotions basket data
        public IPromoBasketRepository PromoBaskets { get; private set; }

        // Constructor that initializes the context, logger, and promotion repository
        public UnitOfWork(SCOPromotionServiceContext context, ILogger<UnitOfWork> loggerFactory, IPromotionRepository promotions)
        {
            // Store the context instance
            _context = context;

            // Store the logger instance
            _logger = loggerFactory;

            // Store the promotion repository instance
            Promotions = promotions;
        }

        // Method for saving changes to the database asynchronously
        public async Task CompleteAsync() => await _context.SaveChangesAsync();

        // Method for disposing the context instance
        public void Dispose() => _context.Dispose();
    }
}