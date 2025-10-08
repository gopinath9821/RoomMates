using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RoomMates.DBContext;
using RoomMates.Models.DBModel;

namespace RoomMates.Controllers
{
    public class AddBillController : Controller
    {
        
        private readonly ConnetionDBContext _context;

        public AddBillController(ConnetionDBContext context)
        {
            _context = context;
        }

        // GET

        [HttpGet]
        public async Task<IActionResult> Bill()
        {
            int userID = HttpContext.Session?.GetInt32("UserID") ?? 1000;
            var UserID = new SqlParameter("@UserId", userID);
            var ActionType = new SqlParameter("@ActionType", 4);

            // Get all shops for this user
            var shops = await _context.ShopBill
                .FromSqlRaw("EXEC GetAllDetails @UserId,@ActionType", UserID, ActionType)
                .ToListAsync();

            ViewBag.ShopList = shops; // pass list directly

            return View(new ShopBill()); // pass empty entity for form
        }
        // ---------- POST ----------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(ShopBill model)
        {
            if (ModelState.IsValid)
            {
                int userID = HttpContext.Session?.GetInt32("UserID") ?? 1000;
                string Name = HttpContext.Session?.GetString("Name") ?? "";

                var shop = new ShopBill
                {                 
                    Date = model.Date,                                        
                    RoomRent = model.RoomRent,
                    EBBill = model.EBBill,
                    WaterBill = model.WaterBill,
                    AkkaBill = model.AkkaBill,
                    WifiNetwork = model.WifiNetwork
                };


                _context.ShopBill.Add(shop);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Shop item saved successfully!";

                // Redirect to GET action to avoid "view not found" and reload data
                return RedirectToAction("Bill");
            }

            // If validation fails, reload data for grid
            int user = HttpContext.Session?.GetInt32("UserID") ?? 1000;
            var param = new SqlParameter("@UserId", user);
            var updatedList = await _context.ShopBill
                .FromSqlRaw("EXEC GetUserById @UserId", param)
                .ToListAsync();



            return View("Bill", updatedList); // <-- explicitly use "UserShop" view
        }

    }
}
