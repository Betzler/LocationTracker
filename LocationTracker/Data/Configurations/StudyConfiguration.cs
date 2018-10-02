using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LocationTracker.Models;

namespace LocationTracker.Data.Configurations
{
    public class StudyConfiguration : IEntityTypeConfiguration<Study>
    {
        public void Configure(EntityTypeBuilder<Study> builder)
        {
            builder.ToTable("study");

            builder.HasKey(s => s.StudyID);
            builder.Property(s => s.StudyID).IsRequired(true).HasColumnName("id");

            builder.Property(s => s.StudyName).IsRequired(true).HasMaxLength(50).HasColumnName("name");
            builder.HasMany(s => s.LocationStudies).WithOne(s => s.Study);

            builder.Property(s => s.StudySize).IsRequired(false).HasColumnName("size");
        }
    }
}
