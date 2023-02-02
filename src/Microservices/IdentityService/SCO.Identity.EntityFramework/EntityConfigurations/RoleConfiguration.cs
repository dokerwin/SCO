using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCO.Identity.Domain.Entities.Employees;

namespace SCO.Identity.EntityFramework.EntityConfigurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> entityTypeBuilder)
    {
        entityTypeBuilder.Property(b => b.Name).IsRequired().HasMaxLength(50);
    }
}

