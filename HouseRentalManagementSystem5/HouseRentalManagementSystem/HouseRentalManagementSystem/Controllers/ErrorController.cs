using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseRentalManagementSystem.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult HttpStatusCodeErrorHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMassage = "We are working on this page";
                    break;
                default:
                    ViewBag.ErrorMassage = "Some Error Occored. Please Contact system Administator";
                    break;
            }
            return View("Error");
        }
        public IActionResult Message()
        {
            return View("Message");
        }
    }
}
