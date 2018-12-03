using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using LocationTracker.Models;
using LocationTracker.Data.Configurations;

namespace LocationTracker.Data
{
    public class TrackerContext : DbContext
    {
        public TrackerContext(DbContextOptions<TrackerContext> options)
            : base(options)
        {
        }

        public DbSet<Location> Location { get; set; }
        public DbSet<Division> Division { get; set; }
        public DbSet<BusinessUnit> BusinessUnit { get; set; }
        public DbSet<Address>  Address { get; set; }
        public DbSet<Study> Study { get; set; }
        public DbSet<LocationStudy> LocationStudy { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<StudyType> StudyType { get; set; }
        public DbSet<StudyHistory> StudyHistory { get; set; }
        public DbSet<StudyResult> StudyResult { get; set; }
        public DbSet<Assessment> Assessment { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Subdivision> Subdivision { get; set; }
        public DbSet<Vendor> Vendor { get; set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfiguration(new LocationConfiguration());
            modelBuilder.ApplyConfiguration(new DivisionConfiguration());
            modelBuilder.ApplyConfiguration(new BusinessUnitConfiguration());
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new StudyConfiguration());
            modelBuilder.ApplyConfiguration(new LocationStudyConfiguration());
            modelBuilder.ApplyConfiguration(new StatusConfiguration());
            modelBuilder.ApplyConfiguration(new StudyHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new StudyTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StudyResultConfiguration());
            modelBuilder.ApplyConfiguration(new AssessmentConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new SubdivisionConfiguration());
            modelBuilder.ApplyConfiguration(new VendorConfiguration());
        }
    }
}
