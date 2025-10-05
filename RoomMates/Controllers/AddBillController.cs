using Microsoft.AspNetCore.Mvc;

namespace RoomMates.Controllers
{
    public class AddBillController : Controller
    {
        public IActionResult Bill()
        {
            return View();
        }
    }
}
