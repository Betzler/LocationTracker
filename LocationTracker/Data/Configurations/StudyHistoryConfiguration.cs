using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LocationTracker.Models;

namespace LocationTracker.Data.Configurations
{
    public class StudyHistoryConfiguration : IEntityTypeConfiguration<StudyHistory>
    {
        public void Configure(EntityTypeBuilder<StudyHistory> builder)
        {
            builder.ToTable("study_history");

            builder.HasKey(s => s.StudyHistoryID);
            builder.Property(s => s.StudyHistoryID).HasColumnName("id");

            builder.Property(s => s.StudyID).IsRequired(true).HasColumnName("study_id");
            builder.HasOne(s => s.Study).WithMany(s => s.StudyHistory);
            
            builder.Property(s => s.StudyTypeID).HasColumnName("study_type_id");
            builder.HasOne(s => s.StudyType).WithMany(s => s.StudyHistories);

            builder.Property(s => s.StatusID).IsRequired(true).HasColumnName("status_id");
            builder.HasOne(s => s.Status).WithMany(s => s.StudyHistories);

        }
    }
}
