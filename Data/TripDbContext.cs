using Microsoft.EntityFrameworkCore;
using TripManager.Models;

namespace TripManager.Data
{
    public class TripDbContext : DbContext
    {
        public TripDbContext(DbContextOptions<TripDbContext> options) :
            base(options)
        {
        }

        // DbSets
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Person> People { get; set; }

        // By default the name of the table will be the name of the dbset, here we override that
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trip>().ToTable("Trip");
            modelBuilder.Entity<Location>().ToTable("Location");
            modelBuilder.Entity<Person>().ToTable("Person");
        }

    }
}
