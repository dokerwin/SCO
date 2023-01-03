using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SCO.Domain.Entities.Product;

namespace SCO.EntityFramework.EntityConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> entityTypeBuilder)
    {
        entityTypeBuilder.Property(b => b.Name).IsRequired().HasMaxLength(100); ;
        entityTypeBuilder.Property(b => b.Price).IsRequired();
        entityTypeBuilder.Property(b => b.VatId).IsRequired();
        entityTypeBuilder.Property(b => b.TaxId).IsRequired();
        entityTypeBuilder.Property(b => b.ProductOwnerId).IsRequired();
    }
}

