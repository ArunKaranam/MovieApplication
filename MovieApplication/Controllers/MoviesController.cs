using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApplication.Data;

namespace MovieApplication.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDBContext _context;
        public MoviesController(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var allMovies = await _context.Movies.Include(c=>c.Cinema).OrderBy(c=>c.Name).ToListAsync();
            return View(allMovies);
        }
    }
}
