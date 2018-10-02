using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LocationTracker.Models;

namespace LocationTracker.Data.Configurations
{
    public class LocationStudyConfiguration : IEntityTypeConfiguration<LocationStudy>
    {
        public void Configure(EntityTypeBuilder<LocationStudy> builder)
        {
            builder.ToTable("location_study");

            builder.Property(ls => ls.LocationID).IsRequired(true).HasColumnName("location_id");

            builder.Property(ls => ls.StudyID).IsRequired(true).HasColumnName("study_id");

            builder.HasKey(ls => new { ls.StudyID, ls.LocationID });
            builder.HasOne(ls => ls.Location).WithMany(l => l.LocationStudies).HasForeignKey(ls => ls.LocationID);
            builder.HasOne(ls => ls.Study).WithMany(s => s.LocationStudies).HasForeignKey(ls => ls.StudyID);
        }
    }
}
