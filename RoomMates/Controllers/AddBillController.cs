using Microsoft.AspNetCore.Mvc;
using RoomMates.DBContext;
using RoomMates.Models.DBModel;

namespace RoomMates.Controllers
{
    public class AddBillController : Controller
    {
        public IActionResult Bill()
        {
            return View();
        }

        private readonly ConnetionDBContext _context;

        public AddBillController(ConnetionDBContext context)
        {
            _context = context;
        }



        // POST: ShopBill/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(ShopBill model)
        {
            if (ModelState.IsValid)
            {
                _context.ShopBill.Add(model);
                await _context.SaveChangesAsync();
                ViewBag.Success = true;
                ModelState.Clear();
                // ✅ Pass success message using TempData (survives one redirect)
                TempData["SuccessMessage"] = "Shop Bill Saved Successfully!";

                // Redirect to prevent resubmission on refresh
                return RedirectToAction("Bill");

            }

            return View(model);
        }

    }
}
