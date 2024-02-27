using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TripManager.Data;
using TripManager.Models;
using Microsoft.EntityFrameworkCore;

namespace TripManager.Controllers
{
    public class LocationController : Controller
    {
        private readonly TripDbContext _context;
        public LocationController(TripDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Location> locations = _context.Locations.ToList();
            return View(locations);
        }
    }
}
