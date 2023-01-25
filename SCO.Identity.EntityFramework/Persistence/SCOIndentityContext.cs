using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SCO.Identity.Domain;
using SCO.Identity.Domain.Entities.Employees;

namespace SCO.Identity.EntityFramework.Persistence;

public class SCOIndentityContext : DbContext
{
    private readonly IConfiguration _configuration;
    public SCOIndentityContext(DbContextOptions<SCOIndentityContext> dbContextOptions, IConfiguration configuration)
           : base()
    {
     _configuration = configuration;
    }

    public virtual DbSet<Cashier> Cashiers { get; set; }
    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SCOIndentityContext).Assembly);
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(_configuration.GetConnectionString("SCOConnectionString"));
    }
}

