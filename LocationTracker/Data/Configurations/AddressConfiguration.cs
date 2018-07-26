using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using LocationTracker.Models;

namespace LocationTracker.Data.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("address");

            builder.HasKey(a => a.AddressID);
            builder.Property(a => a.AddressID).IsRequired(true).HasColumnName("id");

            builder.Property(a => a.FirstAddress).IsRequired(false).HasMaxLength(50).HasColumnName("address_1");

            builder.Property(a => a.SecondAddress).IsRequired(false).HasMaxLength(50).HasColumnName("address_2");

            builder.Property(a => a.City).IsRequired(false).HasMaxLength(50).HasColumnName("city");

            builder.Property(a => a.StateProvince).IsRequired(false).HasMaxLength(50).HasColumnName("state_province");

            builder.Property(a => a.Country).IsRequired(true).HasMaxLength(50).HasColumnName("country");

            builder.Property(a => a.PostalCode).IsRequired(false).HasMaxLength(10).HasColumnName("postal_code");

            builder.Property(a => a.Lattitude).IsRequired(false).HasColumnName("lattitude");

            builder.Property(a => a.Longitude).IsRequired(false).HasColumnName("longitude");

        }
    }
}
