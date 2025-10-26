using Microsoft.AspNetCore.Mvc;
using RoomMates.DAL;

namespace RoomMates.Controllers
{
    public class ViewBillController : Controller
    {
        private readonly DataAccess _repo;

        public ViewBillController(DataAccess repo)
        {
            _repo = repo;
        }

        public IActionResult Index(int? month)
        {
            int userID = HttpContext.Session?.GetInt32("UserID") ?? 1000;
            int actionType = 5;

            var bills = _repo.GetUserBills(userID, actionType, month);
            return View(bills);
        }
    }
}
