using System.Linq;
using Fall2024_Assignment3_ggazzam.Data;
using Microsoft.AspNetCore.Mvc;

public class MoviesController : Controller
{
    private readonly ApplicationDbContext _context;

    public MoviesController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult GetMovieTitles()
    {
        var titles = _context.Movies.Select(m => m.Title).ToList();
        return Json(titles);
    }

    public IActionResult GetMovieDetails(string title)
    {
        var movie = _context.Movies.FirstOrDefault(m => m.Title == title);
        if (movie != null)
        {
            return Json(new
            {
                movie.IMBDLink,
                movie.Genre,
                movie.YearOfRelease
            });
        }
        return NotFound();
    }
}
