using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SCO.PromotionService.Domain.Entities;

namespace SCO.PromotionService.EntityFramework.Persistence;

public class SCOPromotionServiceContext : DbContext
{
    private readonly IConfiguration _configuration;
    public SCOPromotionServiceContext(DbContextOptions<SCOPromotionServiceContext> dbContextOptions, IConfiguration configuration)
           : base()
    {
        _configuration = configuration;
    }

    public virtual DbSet<Promotion> Promotions { get; set; }

    public virtual DbSet<PromoBasket> PromoBaskets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SCOPromotionServiceContext).Assembly);
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(_configuration.GetConnectionString("SCO_PromotionService_ConnectionString"));
    }
}

