using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SCO.Domain.Entities.Product;

namespace SCO.EntityFramework.EntityConfigurations;

public class ProductOwnerConfiguration : IEntityTypeConfiguration<ProductOwner>
{
    public void Configure(EntityTypeBuilder<ProductOwner> entityTypeBuilder)
    {
        entityTypeBuilder.Property(b => b.Type).IsRequired();
    }
}


