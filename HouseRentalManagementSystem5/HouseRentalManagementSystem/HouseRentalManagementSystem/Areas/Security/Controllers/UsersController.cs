using HouseRentalManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HouseRentalManagementSystem.Areas.Security.Controllers
{
    
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly IWebHostEnvironment iWebHostEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;
        public UsersController(UserManager<ApplicationUser> userManager, IWebHostEnvironment _iWebHostEnvironment)
        {
            _userManager = userManager;
            iWebHostEnvironment = _iWebHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            var allUsersExceptCurrentUser = await _userManager.Users.Where(a => a.Id != currentUser.Id).ToListAsync();
            return View(allUsersExceptCurrentUser);
        }
        public async Task<ActionResult> Delete(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user.ImageName != null)
            {
                string uploadFolder = Path.Combine(iWebHostEnvironment.WebRootPath, "images/user_images");
                DeleteExistingImage(Path.Combine(uploadFolder, user.ImageName));
            }
            await _userManager.DeleteAsync(user);
            return RedirectToAction("Index");
        }
        private void DeleteExistingImage(string imagePath)
        {
            FileInfo fileObj = new FileInfo(imagePath);
            if (fileObj.Exists)
            {
                fileObj.Delete();
            }
        }

    }
}
