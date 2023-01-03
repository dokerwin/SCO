using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCO.Domain.Entities.Product;

namespace SCO.EntityFramework.EntityConfigurations;

public class TaxConfiguration : IEntityTypeConfiguration<Tax>
{
    public void Configure(EntityTypeBuilder<Tax> entityTypeBuilder)
    {
        entityTypeBuilder.Property(b => b.Percent).IsRequired();
    }
}

