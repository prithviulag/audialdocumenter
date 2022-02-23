using Microsoft.AspNetCore.Mvc;
using MVCProj1.Models;
using System.Diagnostics;

namespace MVCProj1.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Entry()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Entry(Audio song)
        {
            if (ModelState.IsValid) //need to succeed in this in order for data to pass to view
            {
                ViewData["songTitle"] = song.SongName;
                ViewData["link"] = Uri.IsWellFormedUriString(song.SongLink, UriKind.Absolute) ?
                    song.SongLink : "https://" + song.SongLink;
                ViewData["notes"] = song.Notes;
                ViewData["notesPresent"] = !String.IsNullOrEmpty(song.Notes);

                ViewData["validModel"] = true; //removes form from view

                return View(song);
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}