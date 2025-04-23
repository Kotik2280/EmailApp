using EmailApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmailApp.Controllers
{
    public class HomeController : Controller
    {
        DataContext _db;
        public HomeController(DataContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> UsersList()
        {
            return View(await _db.Users.ToListAsync());
        }
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(User user)
        {
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            return RedirectToRoute("Main");
        }
        public IActionResult Autorization()
        {
            return View();
        }
    }
}
