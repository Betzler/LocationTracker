using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LocationTracker.Models;

namespace LocationTracker.Data.Configurations
{
    public class SubdivisionConfiguration : IEntityTypeConfiguration<Subdivision>
    {
        public void Configure(EntityTypeBuilder<Subdivision> builder)
        {
            builder.ToTable("subdivision");

            builder.HasKey(s => s.SubdivisionID);
            builder.Property(s => s.SubdivisionID).IsRequired(true).HasColumnName("id");

            builder.Property(s => s.CountryID).IsRequired(true).HasColumnName("country_id");

            builder.HasIndex(s => s.AlphaTwo).IsUnique();
            builder.Property(s => s.AlphaTwo).IsRequired(true).HasMaxLength(2).HasColumnName("iso_alpha_2");

            builder.Property(s => s.SubdivisionName).IsRequired(true).HasColumnName("name");

            builder.HasOne(s => s.Country).WithMany(c => c.Subdivisions);
        }
    }
}
