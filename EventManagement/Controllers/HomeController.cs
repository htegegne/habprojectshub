using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using EventManagement.Models;
//using AppUserManager.Services;
namespace EventManagement.Controllers
{
    [Area("EventManagement")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
       // private readonly IAppUserService _appUserService; // Inject AppUserService


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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
