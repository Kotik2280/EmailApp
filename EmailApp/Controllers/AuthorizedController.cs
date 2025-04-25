using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmailApp.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using EmailApp.Models.View;

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
            List<MessageData> messageDataList = await _db.Messages.Where(m => m.ReceiverEmail == user.Name)?.ToListAsync();
            MessageData messageData = new MessageData();

            return View(new UserMessageData() { User = user, Message = messageData, MessageDataList = messageDataList});
        }
        public async Task<IActionResult> MessageList()
        {
            return PartialView();
        }
        public IActionResult SendMessage()
        {
            return PartialView();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> SendMessage(MessageData messageData)
        {
            messageData.Date = DateTime.Now;
            messageData.SenderEmail = HttpContext.User.Identity?.Name;

            await _db.Messages.AddAsync(messageData);
            await _db.SaveChangesAsync();

            return RedirectToRoute("Profile");
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Quit()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToRoute("Main");
        }
    }
}
