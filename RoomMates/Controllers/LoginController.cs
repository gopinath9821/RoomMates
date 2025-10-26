using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoomMates.DBContext;
using RoomMates.Models;
using RoomMates.Models.DBModel;

namespace RoomMates.Controllers
{
    public class LoginController : Controller
    {
        private readonly ConnetionDBContext _context;

        public LoginController(ConnetionDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.UserProfile
                    .FirstOrDefaultAsync(u => u.UserName == model.Username && u.Password == model.Password);

                if (user != null)
                {
                    // ✅ Store user details in session
                    HttpContext.Session.SetInt32("UserID", user.UserID);
                    HttpContext.Session.SetString("Username", user.UserName);
                    HttpContext.Session.SetString("Name", user.Name ?? "");

                    // ✅ Redirect after success
                    return RedirectToAction("Index", "Home");
                }

                // Use TempData to pass message for popup
                TempData["ErrorMessage"] = "Invalid username or password";
            }

            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
