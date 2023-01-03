using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCO.Identity.Domain.Entities.Employees;

namespace SCO.Identity.EntityFramework.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<Cashier>
{
    public void Configure(EntityTypeBuilder<Cashier> entityTypeBuilder)
    {
        entityTypeBuilder.Property(b => b.RoleId).IsRequired();
        entityTypeBuilder.Property(b => b.CompanyId).IsRequired();
        entityTypeBuilder.Property(b => b.Firstname).IsRequired().HasMaxLength(50);
        entityTypeBuilder.Property(b => b.LastName).IsRequired().HasMaxLength(50);
        entityTypeBuilder.Property(b => b.Email).IsRequired().HasMaxLength(50);
        entityTypeBuilder.Property(b => b.PasswordHash).IsRequired();
    }
}
