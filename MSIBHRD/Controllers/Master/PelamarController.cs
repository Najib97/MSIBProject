using Microsoft.AspNetCore.Mvc;

namespace MSIBHRD.Controllers.Master
{
    public class PelamarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return null;
        }
    }
}
