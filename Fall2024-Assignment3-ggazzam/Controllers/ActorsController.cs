using System.Linq;
using Fall2024_Assignment3_ggazzam.Data;
using Microsoft.AspNetCore.Mvc;

public class ActorsController : Controller
{
    private readonly ApplicationDbContext _context;

    public ActorsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult GetActorNames()
    {
        var names = _context.Actors.Select(m => m.Name).ToList();
        return Json(names);
    }

    public IActionResult GetActorDetails(string name) 
    {
        var actor = _context.Actors.FirstOrDefault(m => m.Name == name);
        if (actor != null)
        {
            return Json(new
            {
                actor.Gender,
                actor.Age,
                actor.IMDBLink
            });
        }
        return NotFound();
    }
}
