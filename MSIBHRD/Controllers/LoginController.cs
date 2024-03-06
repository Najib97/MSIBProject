using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MSIBHRD.Models.EF;
using System.Security.Cryptography;
using System.Text;

namespace MSIBHRD.Controllers
{
    public class LoginController : Controller
    {
        private readonly ModelContext _context;
        string strViewPath = string.Empty;
        public LoginController(ModelContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            var model = new Models.Login.Register();

            return View(model);
        }

        [HttpPost]
        public IActionResult Register(Models.Login.Register input)
        {
            string encrptPass = Utility.Helper.GenerateMD5Hash(input.Password);
            var addToDb = new Models.EF.User()
            {
                Username = input.Username,
                Password = encrptPass,
                Email = input.Email,
            };

            _context.Users.Add(addToDb);
            _context.SaveChanges();

            TempData["register"] = "Registrasi Berhasil Silahkan Login";
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Login(string Username, string Password)
        {
            string encrptPass = Utility.Helper.GenerateMD5Hash(Password);

            var checkUsername = _context.Users.Where(x=>x.Username == Username).FirstOrDefault();
            if (checkUsername != null)
            {
                var checkPassword = checkUsername.Password == encrptPass;
                if (checkPassword)
                {
                    HttpContext.Session.SetString("user", checkUsername.Username);
                    return RedirectToAction("Index", "Home");
                }
            }

            TempData["error"] = "USERNAME/PASSWORD SALAH";
            return RedirectToAction("Index","Login");
        }
    }
}
