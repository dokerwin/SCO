using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SCO.Domain.Entities;
using SCO.Domain.Entities.Employees;
using SCO.Domain.Entities.Product;

namespace SCO.EntityFramework.Persistence;

public class SCOContext : DbContext
{
    private readonly IConfiguration _configuration;
    public SCOContext(DbContextOptions<SCOContext> dbContextOptions, IConfiguration configuration)
           : base()
    {
     _configuration = configuration;
    }

    public virtual DbSet<Language> Languages { get; set; }
    public virtual DbSet<PointConfiguration> PointConfigurations { get; set; }
    public virtual DbSet<Cashier> Cashiers { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<Shift> Shifts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SCOContext).Assembly);
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("SCOConnectionString"));
    }
}

