using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using MSIBHRD.Models;
using MSIBHRD.Models.EF;

namespace MSIBHRD.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ModelContext _context;

        public HomeController(ILogger<HomeController> logger, ModelContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var session = HttpContext.Session.GetString("user");
            if (session == null)
            {
                TempData["error"] = "Session telah habis, silahkan login ulang";
                return RedirectToAction("Index", "Login");
            }

            var model = new Models.HomeVM.Index(_context, session);
            return View(model);
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