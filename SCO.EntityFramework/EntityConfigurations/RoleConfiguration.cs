using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCO.Domain.Entities.Employees;

namespace SCO.EntityFramework.EntityConfigurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> entityTypeBuilder)
    {
        entityTypeBuilder.Property(b => b.Name).IsRequired().HasMaxLength(50);
    }
}

