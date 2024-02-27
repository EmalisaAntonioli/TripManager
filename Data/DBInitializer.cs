using TripManager.Models;

namespace TripManager.Data
{
    public static class DBInitializer
    {
        public static void Initialize(TripDbContext context)
        {
            // This will recreate the db if there is none
            context.Database.EnsureCreated();

            // Check if there are any trips, returns if so, so that it is not unnecessarily being seeded
            if (context.Trips.Any())
            {
                return;
            }

            // People
            context.People.AddRange(
                new Person { FirstName = "Elon", Name = "Musk", Role = "User" },
                new Person { FirstName = "Bill", Name = "Gates", Role = "Admin" },
                new Person { FirstName = "Michaël", Name = "Cloots", Role = "Teacher" });

            // Locations
            context.Locations.AddRange(
                new Location { Name = "Malibu Beach", Description = "Malibu Beach" },
                new Location { Name = "Kilimanjaro", Description = "Kilimanjaro" },
                new Location { Name = "Rocky Mountains", Description = "Rocky Mountains" });

            // First save
            context.SaveChanges();

            // Trips - needs to be added last because of the FKs
            context.Trips.AddRange(
                new Trip
                {
                    StartDate = new DateTime(2024, 7, 1),
                    EndDate = new DateTime(2024, 7, 31),
                    DestinationID = 1,
                    PersonID = 1
                },
                new Trip
                {
                    StartDate = new DateTime(2024, 8, 1),
                    EndDate = new DateTime(2024, 8, 31),
                    DestinationID = 2,
                    PersonID = 2
                },
                new Trip
                {
                    StartDate = new DateTime(2023, 7, 1),
                    EndDate = new DateTime(2023, 7, 31),
                    DestinationID = 3,
                    PersonID = 3
                }
                );

            // Second save
            context.SaveChanges();
        }
    }
}
