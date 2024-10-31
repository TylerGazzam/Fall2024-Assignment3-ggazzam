using System.Diagnostics;
using Fall2024_Assignment3_ggazzam.Data;
using Fall2024_Assignment3_ggazzam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fall2024_Assignment3_ggazzam.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ActorReviews()
        {
            return View();
        }

        public IActionResult MovieReviews()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

      


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

   


}
