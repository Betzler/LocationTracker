using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using LocationTracker.Models;

namespace LocationTracker.Data.Configurations
{
    public class VendorConfiguration : IEntityTypeConfiguration<Vendor>
    {
        public void Configure(EntityTypeBuilder<Vendor> builder)
        {
            builder.ToTable("vendor");

            builder.HasKey(v => v.VendorID);
            builder.Property(v => v.VendorID).IsRequired(true).HasColumnName("id");

            builder.Property(v => v.VendorNumber).IsRequired(true).HasColumnName("number");

            builder.Property(v => v.VendorName).IsRequired(true).HasMaxLength(50).HasColumnName("name");

            builder.HasMany(v => v.Assessments).WithOne(a => a.Vendor);
            //builder.HasMany(v => v.StudyHistories).WithOne(s => s.Vendor);
        }
    }
}
