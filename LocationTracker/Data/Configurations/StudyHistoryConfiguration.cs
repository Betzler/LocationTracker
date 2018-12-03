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
            builder.HasOne(sh => sh.Study).WithMany(s => s.StudyHistory).HasForeignKey(s => s.StudyID);
            
            builder.Property(s => s.StudyTypeID).IsRequired(true).HasColumnName("study_type_id");
            builder.HasOne(sh => sh.StudyType).WithMany(st => st.StudyHistories);

            builder.Property(s => s.StatusID).IsRequired(true).HasColumnName("status_id");
            builder.HasOne(sh => sh.Status).WithMany(s => s.StudyHistories);

            builder.Property(s => s.VendorID).IsRequired(true).HasColumnName("vendor_id");
            builder.HasOne(s => s.Vendor).WithMany(v => v.StudyHistories);

            builder.Property(s => s.UnderratedIssues).IsRequired(false).HasColumnName("underrated_issues");

            builder.Property(s => s.ArcFlashIssues).IsRequired(false).HasColumnName("arc_flash_issues");

            builder.Property(s => s.EquipmentProtectionIssues).IsRequired(false).HasColumnName("equipment_protection_issues");

            builder.Property(s => s.StartDate).IsRequired(true).HasColumnType("date").HasColumnName("start_date");

            builder.Property(s => s.EndDate).IsRequired(false).HasColumnType("date").HasColumnName("end_date");

            builder.Property(s => s.ExpirationDate).IsRequired(false).HasColumnType("date").HasColumnName("expire_date");

            builder.Property(s => s.Comment).IsRequired(false).HasColumnName("comment");
        }
    }
}
