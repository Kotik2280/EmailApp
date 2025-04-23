using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }

        public IActionResult Autorization()
        {
            return View();
        }
    }
}
