using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LocationTracker.Models;

namespace LocationTracker.Data.Configurations
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("status");

            builder.HasKey(s => s.StatusID);
            builder.Property(s => s.StatusID).HasColumnName("id");

            builder.Property(s => s.StatusName).IsRequired(true).HasMaxLength(50).HasColumnName("name");

            builder.HasMany(s => s.StudyHistories).WithOne(s => s.Status);
        }
    }
}
