
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RoomMates.DBContext;
using RoomMates.Models.DBModel;

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

        [HttpGet]
        public async Task<IActionResult> UserShop()
        {
            int userID = HttpContext.Session?.GetInt32("UserID") ?? 1000;
            var UserID = new SqlParameter("@UserId", userID);
            var ActionType = new SqlParameter("@ActionType", 3);

            // Get all shops for this user
            var shops = await _context.OwnUserShop
                .FromSqlRaw("EXEC GetAllDetails @UserId,@ActionType", UserID, ActionType)
                .ToListAsync();

            ViewBag.ShopList = shops; // pass list directly

            return View(new UserShop()); // pass empty entity for form
        }
        // ---------- POST ----------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(UserShop model)
        {
            if (ModelState.IsValid)
            {
                int userID = HttpContext.Session?.GetInt32("UserID") ?? 1000;
                string Name = HttpContext.Session?.GetString("Name") ?? "";

                var shop = new UserShop
                {
                    UserID = userID,
                    Date = model.Date,
                    Name = Name,
                    ProductName = model.ProductName,
                    Price = model.Price
                };

                _context.OwnUserShop.Add(shop);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Shop item saved successfully!";

                // Redirect to GET action to avoid "view not found" and reload data
                return RedirectToAction("UserShop");
            }

            // If validation fails, reload data for grid
            int user = HttpContext.Session?.GetInt32("UserID") ?? 1000;
            var param = new SqlParameter("@UserId", user);
            var updatedList = await _context.OwnUserShop
                .FromSqlRaw("EXEC GetUserById @UserId", param)
                .ToListAsync();



            return View("UserShop", updatedList); // <-- explicitly use "UserShop" view
        }

    }
}

