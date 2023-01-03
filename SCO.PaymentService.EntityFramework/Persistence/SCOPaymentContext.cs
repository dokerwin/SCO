using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SCO.PaymentService.Domain.Enteties;
using System.Reflection.Metadata;

namespace SCO.PaymentService.EntityFramework.Persistence;

public class SCOPaymentContext : DbContext
{
    private readonly IConfiguration _configuration;
    public SCOPaymentContext(DbContextOptions<SCOPaymentContext> dbContextOptions, IConfiguration configuration)
           : base()
    {
        _configuration = configuration;
    }
    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<MethodOfPayment> MOPs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SCOPaymentContext).Assembly);

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("SCO_PaymentService_ConnectionString"));
    }
}

