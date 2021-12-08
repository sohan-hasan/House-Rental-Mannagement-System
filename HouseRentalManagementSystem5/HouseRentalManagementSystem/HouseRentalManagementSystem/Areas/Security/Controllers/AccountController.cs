using HouseRentalManagementSystem.Models;
using HouseRentalManagementSystem.SecurityViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HouseRentalManagementSystem.Areas.Security.Controllers
{

    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LoginViewModel> _logger; 
        private readonly IWebHostEnvironment iWebHostEnvironment;

        public AccountController(UserManager<ApplicationUser> userManager, ILogger<LoginViewModel> logger, SignInManager<ApplicationUser> signInManager, IWebHostEnvironment _iWebHostEnvironment)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            _logger = logger;
            iWebHostEnvironment = _iWebHostEnvironment;

        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.IsChecked, false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return RedirectToAction(returnUrl);
                    }
                    _logger.LogInformation("User logged in.");
                    return RedirectToAction("Dashboard", "Home", new { area = "Common" });
                }
                ModelState.AddModelError("", "Invalid Login attempt");
            }
            return View(model);
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Singup()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Singup(UserModelView objModel)
        {
            string uniqueImageName = null;
            if (ModelState.IsValid)
            {
                if (objModel.Photo != null)
                {
                    string uploadFolder = Path.Combine(iWebHostEnvironment.WebRootPath, "images/user_images");
                    uniqueImageName = Guid.NewGuid().ToString() + "_" + objModel.Photo.FileName;
                    string filePath = Path.Combine(uploadFolder, uniqueImageName);
                    FileStream fileStream = new FileStream(filePath, FileMode.Create);
                    objModel.Photo.CopyTo(fileStream);
                    fileStream.Close();
                    objModel.ImageName = uniqueImageName;
                }
                var user = new ApplicationUser
                {
                    FirstName = objModel.FirstName,
                    LastName = objModel.LastName,
                    UserName = objModel.UserName,
                    PhoneNumber = objModel.Phone,
                    Email = objModel.Email,
                    ImageName = objModel.ImageName,
                };
                var result = await _userManager.CreateAsync(user, objModel.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Dashboard", "Home", new { area = "Common" });
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }
            return View(objModel);
        }

        public async Task<IActionResult> Singout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account", new { area = "Security" });
        }
    }
}
