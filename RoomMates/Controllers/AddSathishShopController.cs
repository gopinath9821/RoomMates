using Microsoft.AspNetCore.Mvc;
using RoomMates.DBContext;
using RoomMates.Models.DBModel;
using System.Threading.Tasks;

namespace RoomMates.Controllers
{
    public class AddSathishShop : Controller
    {
        private readonly ConnetionDBContext _context;

        public AddSathishShop(ConnetionDBContext context)
        {
            _context = context;
        }

        // GET
        public IActionResult SathishShop()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SathishShop(SathishShop model)
        {
            model.UserID = HttpContext.Session.GetInt32("UserID") ?? 1000;
            _context.SathishShop.Add(model);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Shop item saved successfully!";
            return RedirectToAction("SathishShop");

        }
    }
}
