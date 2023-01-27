using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SCO.ShiftService.Domain.Entities;

namespace SCO.ShiftService.EntityFramework.Persistence;

public class SCOShiftContext : DbContext
{
    private readonly IConfiguration _configuration;
    public SCOShiftContext(DbContextOptions<SCOShiftContext> dbContextOptions, IConfiguration configuration)
           : base()
    {
     _configuration = configuration;
    }

    public virtual DbSet<Shift> Shifts { get; set; }
   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SCOShiftContext).Assembly);
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(_configuration.GetConnectionString("SCO_ShiftService_ConnectionString"));
    }
}

