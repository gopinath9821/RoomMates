using System.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RoomMates.DAL;
using RoomMates.DAL;
using RoomMates.DBContext;
using RoomMates.Models.DBModel;

namespace RoomMates.Controllers
{
    public class AddSathishShop : Controller
    {
        private readonly ConnetionDBContext _context;
        private readonly DataAccess _dataAccess;
        public AddSathishShop(ConnetionDBContext context)
        {
            _context = context;
        }



        [HttpGet]
        public async Task<IActionResult> SathishShop()
        {
            int userID = HttpContext.Session?.GetInt32("UserID") ?? 1000;
            var UserID = new SqlParameter("@UserId", userID);
            var ActionType = new SqlParameter("@ActionType", 2);

            // Get all shops for this user
            var shops = await _context.SathishShop
                .FromSqlRaw("EXEC GetAllDetails @UserId,@ActionType", UserID, ActionType)
                .ToListAsync();

            ViewBag.ShopList = shops; // pass list directly

            return View(new SathishShop()); // pass empty entity for form
        }
        // ---------- POST ----------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(SathishShop model)
        {
            if (ModelState.IsValid)
            {
                int userID = HttpContext.Session?.GetInt32("UserID") ?? 1000;
                string Name = HttpContext.Session?.GetString("Name") ?? "";

                var shop = new SathishShop
                {
                    UserID = userID,
                    Date = model.Date,
                    Name = Name,
                    ProductName = model.ProductName,
                    Price = model.Price
                };

                _context.SathishShop.Add(shop);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Shop item saved successfully!";

                // Redirect to GET action to avoid "view not found" and reload data
                return RedirectToAction("SathishShop");
            }

            // If validation fails, reload data for grid
            int user = HttpContext.Session?.GetInt32("UserID") ?? 1000;
            var param = new SqlParameter("@UserId", user);
            var updatedList = await _context.SathishShop
                .FromSqlRaw("EXEC GetUserById @UserId", param)
                .ToListAsync();



            return View("SathishShop", updatedList); // <-- explicitly use "SathishShop" view
        }

    }
}
