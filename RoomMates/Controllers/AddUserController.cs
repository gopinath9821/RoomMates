using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RoomMates.DBContext;
using RoomMates.Models.DBModel;

namespace RoomMates.Controllers
{
    public class AddUserController : Controller
    {
        private readonly ConnetionDBContext _context;

        public AddUserController(ConnetionDBContext context)
        {
            _context = context;
        }
        // GET: User User



        [HttpGet]
        public async Task<IActionResult> User()
        {
            int userID = HttpContext.Session?.GetInt32("UserID") ?? 1000;
            var UserID = new SqlParameter("@UserId", userID);
            var ActionType = new SqlParameter("@ActionType", 1);

            // Get all shops for this user
            var shops = await _context.UserProfile
                .FromSqlRaw("EXEC GetAllDetails @UserId,@ActionType", UserID, ActionType)
                .ToListAsync();

            ViewBag.ShopList = shops; // pass list directly

            return View(new User()); // pass empty entity for form
        }
        // ---------- POST ----------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(User model)
        {
            if (ModelState.IsValid)
            {


                var shop = new User
                {
                    UserName = model.UserName,        // assign the username
                    Password = model.Password,        // assign the password
                    Name = model.Name,                // assign full name
                    DOB = model.DOB,                  // assign date of birth
                    Photo = model.Photo,              // assign photo (byte array)
                    Email = model.Email,              // assign email
                    MobileNo = model.MobileNo,        // assign mobile number
                    DOJ = model.DOJ,                  // assign date of joining
                    RoomAdvance = model.RoomAdvance   // assign room advance
                };

                _context.UserProfile.Add(shop);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Shop item saved successfully!";

                // Redirect to GET action to avoid "view not found" and reload data
                return RedirectToAction("User");
            }

            // If validation fails, reload data for grid
            int user = HttpContext.Session?.GetInt32("UserID") ?? 1000;
            var param = new SqlParameter("@UserId", user);
            var updatedList = await _context.UserProfile
                .FromSqlRaw("EXEC GetUserById @UserId", param)
                .ToListAsync();



            return View("User", updatedList); // <-- explicitly use "User" view
        }

    }
}
