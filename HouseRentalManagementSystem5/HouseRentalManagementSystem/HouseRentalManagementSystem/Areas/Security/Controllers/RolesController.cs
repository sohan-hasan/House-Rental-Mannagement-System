using HouseRentalManagementSystem.Data;
using HouseRentalManagementSystem.Models;
using HouseRentalManagementSystem.SecurityViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseRentalManagementSystem.Areas.Security.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public RolesController(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(string roleName)
        {
            if (ModelState.IsValid)
            {
                if (roleName != null)
                {
                    await _roleManager.CreateAsync(new ApplicationRole(roleName.Trim()));
                }
                return RedirectToAction("Index");
            }
            return View("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"This {roleId} does not belong With any Role";
                return View("NotFound");
            }
            var model = new UserRolesViewModel
            {
                RoleId = role.Id,
                RoleName = role.Name,
                JsonData = role.JsonData
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UserRolesViewModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.RoleId);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"This {model.RoleId} does not belong With any Role";
                return View("Message");
            }
            else
            {
                if (role.Name != "Admin")
                {
                    role.Name = model.RoleName;
                    role.JsonData = role.JsonData;
                    var result = await _roleManager.UpdateAsync(role);
                    if (result.Succeeded)
                    {
                        UserAndRoleDataInitializer.SeedData(_userManager, _roleManager);
                        return RedirectToAction("Index");
                    }
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }

                }
                else
                {
                    ViewBag.ErrorMessage = $"Admin Role can not be Edited";
                    return View("Message");
                }
            }
            return View(model);
        }
        public async Task<ActionResult> Delete(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role.Name!="Admin")
            {
                await _roleManager.DeleteAsync(role);
                return RedirectToAction("Index");
            }
            else
            {

                ViewBag.ErrorMessage = $"Admin Role can not be deleted";
                return View("Message");
            }
        }
    }
}
