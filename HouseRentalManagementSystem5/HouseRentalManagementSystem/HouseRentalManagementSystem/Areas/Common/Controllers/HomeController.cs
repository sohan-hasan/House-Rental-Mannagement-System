using HouseRentalManagementSystem.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseRentalManagementSystem.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IApartmentBookingRepository iApartmentBookingRepository;
        private readonly IBuildingRepository iBuildingRepository;
        private readonly IApartmentRepository iApartmentRepository;
        private readonly ITenantRepository iTenantRepository;
        public HomeController(IBuildingRepository _iBuildingRepository, IApartmentRepository _iApartmentRepository, ITenantRepository _iTenantRepository, IApartmentBookingRepository _iApartmentBookingRepository) {
            iBuildingRepository = _iBuildingRepository;
            iApartmentRepository = _iApartmentRepository;
            iTenantRepository = _iTenantRepository;
            iApartmentBookingRepository = _iApartmentBookingRepository;
        }
        public IActionResult Dashboard()
        {
            var building = iBuildingRepository.GetAll();
            ViewBag.TotalBuilding = building.Count();
            var apartment = iApartmentRepository.GetAll();
            ViewBag.TotalApartment = apartment.Count();
            var tenant = iTenantRepository.GetAll();
            ViewBag.TotalTenant = tenant.Count();
            var booking = iApartmentBookingRepository.GetAll();
            ViewBag.TotalBooking = booking.Count();
            return View();
        }
    }
}
