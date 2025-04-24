using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmailApp.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace EmailApp.Controllers
{
    [Authorize]
    public class AuthorizedController : Controller
    {
        DataContext _db;
        public AuthorizedController(DataContext db)
        {
            _db = db;
        }
        
        public async Task<IActionResult> Profile()
        {
            string userName = HttpContext.User.Identity.Name;
            User user = await _db.Users.FirstOrDefaultAsync(u => u.Name == userName);
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Quit()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToRoute("Main");
        }
    }
}
