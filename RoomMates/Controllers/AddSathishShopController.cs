using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using RoomMates.DAL;
using RoomMates.DBContext;
using RoomMates.Models.DBModel;
using System.Data;
using System.Threading.Tasks;
using RoomMates.DAL;
using Microsoft.EntityFrameworkCore;
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

        // GET

        [HttpGet]

        public async Task<IActionResult> SathishShop()
        {
            int userID = HttpContext.Session?.GetInt32("UserID") ?? 1000;

            var param = new SqlParameter("@UserId", userID);

            // Execute stored procedure and map to SathishShop model
            var shops = await _context.SathishShop
                .FromSqlRaw("EXEC GetUserById @UserId", param)
                .ToListAsync();

            return View(shops);
        }
        //// POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(SathishShop model)
        {
            model.UserID = HttpContext.Session.GetInt32("UserID") ?? 1000;
            _context.SathishShop.Add(model);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Shop item saved successfully!";
            return RedirectToAction("SathishShop");

        }
    }
}
