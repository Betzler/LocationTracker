using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using LocationTracker.Models;

namespace LocationTracker.Data.Configurations
{
    public class DivisionConfiguration : IEntityTypeConfiguration<Division>
    {
        public void Configure(EntityTypeBuilder<Division> builder)
        {
            builder.ToTable("division");

            builder.HasKey(d => d.DivisionID);
            builder.Property(d => d.DivisionID).IsRequired(true).HasColumnName("id");

            builder.Property(d => d.DivisionName).IsRequired(true).HasMaxLength(50).HasColumnName("name");

            builder.HasMany(d => d.Locations).WithOne(l => l.Division);
        }
    }
}
