using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SCO.BasketService.Domain.Entities;

namespace SCO.BasketService.EntityFramework.Persistence;

public class SCOBasketServiceContext : DbContext
{
    private readonly IConfiguration _configuration;
    public SCOBasketServiceContext(DbContextOptions<SCOBasketServiceContext> dbContextOptions, IConfiguration configuration)
           : base()
    {
        _configuration = configuration;
    }

 
    public virtual DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SCOBasketServiceContext).Assembly);
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(_configuration.GetConnectionString("SCO_BasketService_ConnectionString"));
    }
}

