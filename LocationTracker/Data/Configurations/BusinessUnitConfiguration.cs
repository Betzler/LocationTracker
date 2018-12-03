using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LocationTracker.Models;

namespace LocationTracker.Data.Configurations
{
    public class BusinessUnitConfiguration : IEntityTypeConfiguration<BusinessUnit>
    {
        public void Configure(EntityTypeBuilder<BusinessUnit> builder)
        {
            builder.ToTable("business_unit");

            builder.HasKey(b => b.BusinessUnitID);
            builder.Property(b => b.BusinessUnitID).IsRequired(true).HasColumnName("id");

            builder.Property(b => b.DivisionID).IsRequired(true).HasColumnName("division_id");
            builder.HasOne(b => b.Division).WithMany(d => d.BusinessUnits);

            builder.HasIndex(b => b.BusinessUnitName).IsUnique();
            builder.Property(b => b.BusinessUnitName).IsRequired(true).HasMaxLength(50).HasColumnName("name");

            builder.HasMany(b => b.Locations).WithOne(l => l.BusinessUnit);
        }
    }
}
