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

            builder.HasKey(s => s.StudyResultID);
            builder.Property(s => s.StudyResultID).HasColumnName("id");

            builder.Property(s => s.StudyHistoryID).IsRequired(true).HasColumnName("study_history_id");
            builder.HasOne(s => s.StudyHistory).WithOne(s => s.StudyResult);
            
            builder.Property(s => s.UnderratedIssues).HasColumnName("underrated_issues");

            builder.Property(s => s.ArcFlashIssues).HasColumnName("arc_flash_issues");

            builder.Property(s => s.EquipmentProtectionIssues).HasColumnName("equipment_protection_issues");

        }
    }
}
