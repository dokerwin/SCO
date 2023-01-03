using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SCO.Domain.Entities.Product;

namespace SCO.EntityFramework.EntityConfigurations;

public class VatConfiguration : IEntityTypeConfiguration<Vat>
{
    public void Configure(EntityTypeBuilder<Vat> entityTypeBuilder)
    {
        entityTypeBuilder.Property(b => b.Name).IsRequired().HasMaxLength(50);
        entityTypeBuilder.Property(b => b.Percent).IsRequired();
    }
}