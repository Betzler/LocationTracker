using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LocationTracker.Models;

namespace LocationTracker.Data.Configurations
{
    public class StudyResultConfiguration : IEntityTypeConfiguration<StudyResult>
    {
        public void Configure(EntityTypeBuilder<StudyResult> builder)
        {
            builder.ToTable("study_result");

            builder.HasKey(sr => sr.StudyResultID);
            builder.Property(sr => sr.StudyResultID).HasColumnName("id");

            builder.Property(sr => sr.StudyID).IsRequired(true).HasColumnName("study_id");
            builder.HasOne(sr => sr.Study).WithMany(s => s.StudyResults);
            
            builder.Property(sr => sr.UnderratedIssues).IsRequired(true).HasColumnName("underrated_issues");

            builder.Property(sr => sr.ArcFlashIssues).IsRequired(true).HasColumnName("arc_flash_issues");

            builder.Property(sr => sr.EquipmentProtectionIssues).IsRequired(true).HasColumnName("equipment_protection_issues");

            builder.Property(sr => sr.DateCompleted).IsRequired(true).HasColumnName("date_completed");
        }
    }
}
