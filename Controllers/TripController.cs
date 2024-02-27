using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TripManager.Data;
using TripManager.Models;
using Microsoft.EntityFrameworkCore;


namespace TripManager.Controllers
{
    public class TripController : Controller
    {
        private readonly TripDbContext _context;
        public TripController(TripDbContext context)
        {
            _context = context;
        }

        // /Trip
        public IActionResult Index()
        {
            // Get trips
            // SELECT t.*, l.* FROM Trip t INNER JOIN Location l on t.DestinationID = l.ID
            List<Trip> trips = 
                _context.Trips.Include(t => t.Destination)
                .Where(t => t.StartDate >= new DateTime(2024,1,1))
                .OrderBy(t => t.StartDate)
                .ToList();

            Trip singleTrip = _context.Trips
                .SingleOrDefault(t => t.ID ==1);

            List<DateTime> test = 
                _context.Trips.Select(t => t.StartDate).ToList();

            // Note that we are choosing not to use ViewData or ViewBag
            return View(trips);
        }

        // ACTION METHOD (general name for method in controller)
        // /Trip/Detail/7
        public IActionResult Details(int id)
        {
            Trip trip = _context.Trips.Single(t => t.ID ==id);

            return View(trip);
        }
    }
}
