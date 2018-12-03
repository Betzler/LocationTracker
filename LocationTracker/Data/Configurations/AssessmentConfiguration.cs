using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LocationTracker.Models;

namespace LocationTracker.Data.Configurations
{
    public class AssessmentConfiguration : IEntityTypeConfiguration<Assessment>
    {
        public void Configure(EntityTypeBuilder<Assessment> builder)
        {
            builder.ToTable("assessment");

            builder.HasKey(a => a.AssessmentID);
            builder.Property(a => a.AssessmentID).HasColumnName("id");

            builder.Property(a => a.LocationID).IsRequired(true).HasColumnName("location_id");
            builder.HasOne(a => a.Location).WithMany(l => l.Assessments).HasForeignKey(l => l.LocationID);

            builder.Property(a => a.StatusID).IsRequired(true).HasColumnName("status_id");

            builder.Property(a => a.VendorID).IsRequired(true).HasColumnName("vendor_id");
            builder.HasOne(v => v.Vendor).WithMany(a => a.Assessments);

            builder.Property(a => a.StartDate).IsRequired(true).HasColumnType("date").HasColumnName("start_date");

            builder.Property(a => a.EndDate).IsRequired(false).HasColumnType("date").HasColumnName("end_date");

            builder.Property(a => a.Comment).IsRequired(false).HasColumnName("comment");

            builder.Property(a => a.StudyRequired).IsRequired(false).HasColumnName("study_required");

        }
    }
}
