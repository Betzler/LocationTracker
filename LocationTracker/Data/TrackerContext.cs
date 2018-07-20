using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LocationTracker.Models;

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
            public DbSet<Address>  Address { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>().ToTable("location");
            modelBuilder.Entity<Division>().ToTable("division");
            modelBuilder.Entity<Address>().ToTable("address");
        }
    }
}
