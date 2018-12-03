using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LocationTracker.Models;

namespace LocationTracker.Data.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("country");

            builder.HasKey(c => c.CountryID);
            builder.Property(c => c.CountryID).IsRequired(true).HasColumnName("id");

            builder.HasIndex(c => c.AlphaTwo).IsUnique();
            builder.Property(c => c.AlphaTwo).IsRequired(true).HasMaxLength(2).HasColumnName("iso_alpha_2");

            builder.HasIndex(c => c.AlphaThree).IsUnique();
            builder.Property(c => c.AlphaThree).IsRequired(true).HasMaxLength(3).HasColumnName("iso_alpha_3");

            builder.Property(c => c.CountryName).IsRequired(true).HasColumnName("name");

            builder.HasMany(c => c.Subdivisions).WithOne(s => s.Country);
        }
    }
}
