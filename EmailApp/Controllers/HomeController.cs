using EmailApp.Attributes;
using EmailApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EmailApp.Controllers
{
    [CheckAuthorization]
    public class HomeController : Controller
    {
        DataContext _db;
        public HomeController(DataContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Registration(User user)
        {
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            return RedirectToRoute("Main");
        }
        [HttpGet]
        public IActionResult Authorization()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Authorization(User user)
        {
            if (await _db.Users.FirstOrDefaultAsync(u => u.Name == user.Name && u.Password == user.Password) is null)
                return RedirectToRoute("Main");

            List<Claim> claims = new List<Claim>() { new Claim(ClaimTypes.Name, user.Name) };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return RedirectToRoute("Profile");
        }
    }
}
