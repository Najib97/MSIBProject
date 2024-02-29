using Microsoft.AspNetCore.Mvc;

namespace MSIBHRD.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Username, string Password)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
