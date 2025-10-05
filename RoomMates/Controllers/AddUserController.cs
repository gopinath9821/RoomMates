using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoomMates.DBContext;
using RoomMates.Models.DBModel;
using System;

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
        public IActionResult User()
        {
            var model = new UserPageViewModel
            {
                User = new User(),
                Users = _context.UserProfile.ToList() // fetch all users for grid
            };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> User(User model, IFormFile PhotoFile)
        {
            if (ModelState.IsValid)
            {
                if (PhotoFile != null && PhotoFile.Length > 0)
                {
                    using var ms = new MemoryStream();
                    await PhotoFile.CopyToAsync(ms);
                    model.Photo = ms.ToArray();
                }

                _context.UserProfile.Add(model);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "User saved successfully!";
                return RedirectToAction("User"); // reload same page with popup
            }

            return View(model);
        }

    
    }
}
