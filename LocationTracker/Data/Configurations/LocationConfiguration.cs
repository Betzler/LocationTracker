using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using LocationTracker.Models;

namespace LocationTracker.Data.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder )
        {
            builder.ToTable("location");

            builder.HasKey(l => l.LocationID);
            builder.Property(l => l.LocationID).IsRequired(true).HasColumnName("id");

            builder.Property(l => l.LocationCode).IsRequired(true).HasMaxLength(3).HasColumnName("location_code");


            builder.Property(l => l.DivisionID).IsRequired(false).HasColumnName("division_id");
            builder.HasOne(l => l.Division).WithMany(l => l.Locations);

            builder.Property(l => l.AddressID).IsRequired(false).HasColumnName("address_id");
            builder.HasOne(l => l.Address).WithOne(a => a.Location).HasForeignKey<Location>(l => l.AddressID);
        }
    }
}
