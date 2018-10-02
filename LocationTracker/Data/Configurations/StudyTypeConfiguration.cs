using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LocationTracker.Models;

namespace LocationTracker.Data.Configurations
{
    public class StudyTypeConfiguration : IEntityTypeConfiguration<StudyType>
    {
        public void Configure(EntityTypeBuilder<StudyType> builder)
        {
            builder.ToTable("study_type");

            builder.HasKey(s => s.StudyTypeID);
            builder.Property(s => s.StudyTypeID).HasColumnName("id");

            builder.Property(s => s.StudyTypeName).IsRequired(true).HasMaxLength(50).HasColumnName("name");

            builder.HasMany(s => s.StudyHistories).WithOne(s => s.StudyType);
        }
    }
}
