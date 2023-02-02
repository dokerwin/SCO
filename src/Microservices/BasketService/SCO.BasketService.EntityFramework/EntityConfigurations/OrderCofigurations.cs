using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCO.BasketService.Domain.Entities;

namespace SCO.BasketService.EntityFramework.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> entityTypeBuilder)
    {
        entityTypeBuilder.Property(b => b.Id).IsRequired();
        entityTypeBuilder.Property(b => b.PaymentId).IsRequired();
    }
}
