using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SCO.ProductService.Domain.Entities;

namespace SCO.ProductService.EntityFramework.Persistence;

public class SCOProductContext : DbContext
{
    private readonly IConfiguration _configuration;
    public SCOProductContext(DbContextOptions<SCOProductContext> dbContextOptions, IConfiguration configuration)
           : base()
    {
        _configuration = configuration;
    }
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<ProductOwner> ProductOwners { get; set; }
    public virtual DbSet<ProductType> ProductTypes { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<Vat> Vats { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SCOProductContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("SCO_ProductService_ConnectionString"));
    }
}

