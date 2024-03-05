using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TripManager.Data;
using TripManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;


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
                .Single(t => t.ID ==1);

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

        // GET a page with the form
        // localhost:xxxx/trip/create
        public  IActionResult Create()
        {
            // Here we gather the data to create dropdowns in the form
            // Locations
            // The dropdown list will be bound to the ID of the locations and will show the name
            ViewData["Locations"] = new SelectList(
                _context.Locations.ToList(),
                "ID",
                "Name");

            // People
            ViewData["People"] = new SelectList(
                _context.People.ToList(),
                "ID",
                "FullName");


            return View();
        }

        // POST when the form is submitted
        // Everything is GET by default
        [HttpPost]
        public IActionResult Create(Trip trip)
        {
            // Check if the trip is valid (server side form validation)
            if (ModelState.IsValid) 
            {
                _context.Add(trip);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            // The page with the form is returned if the trip is invalid
            // By passing trip all the previously filled in info will be preserved 
            return View(trip);
        }
    }
}
