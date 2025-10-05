
using Microsoft.AspNetCore.Mvc;
using RoomMates.DBContext;
using RoomMates.Models.DBModel;
using System.Threading.Tasks;

namespace RoomMates.Controllers
{
    public class AddUserOwnShop : Controller
    {
        private readonly ConnetionDBContext _context;

        public AddUserOwnShop(ConnetionDBContext context)
        {
            _context = context;
        }

        // GET
        public IActionResult UserShop()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserShop(UserShop model)
        {
            model.UserID = HttpContext.Session.GetInt32("UserID") ?? 0;
            _context.OwnUserShop.Add(model);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Shop item saved successfully!";
            return RedirectToAction("UserShop");

        }
    }
}
