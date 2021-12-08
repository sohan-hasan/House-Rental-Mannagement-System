using HouseRentalManagementSystem.IRepository;
using HouseRentalManagementSystem.UserViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace HouseRentalManagementSystem.Areas.User.Controllers
{
    [Authorize]
    public class AccessoryItemsController : Controller
    {
        private readonly IApartmentFacilityRepository iApartmentFacilityRepository;
        private readonly IApartmentTypeRepository iApartmentTypeRepository;
        private readonly IBookingStatusRepository iBookingStatusRepository;
        private readonly IPaymentTypeRepository iPaymentTypeRepository;
        public AccessoryItemsController(IApartmentFacilityRepository _iApartmentFacilityRepository, IApartmentTypeRepository _iApartmentTypeRepository,IBookingStatusRepository _iBookingStatusRepository, IPaymentTypeRepository _iPaymentTypeRepository)
        {
            iApartmentFacilityRepository = _iApartmentFacilityRepository;
            iApartmentTypeRepository = _iApartmentTypeRepository;
            iBookingStatusRepository = _iBookingStatusRepository;
            iPaymentTypeRepository = _iPaymentTypeRepository;
        }
        int pageSize = 5;
        public IActionResult Index(int? facilityPage, int? typePage, int? bookingStatusPage, int? paymentTypePage)
        {
            dynamic dynamicItems = new ExpandoObject();
            int facilityPageNumber = (facilityPage ?? 1);
            int typePageNumber = (typePage ?? 1);
            int statusPageNumber = (bookingStatusPage ?? 1);
            int paymentTypePageNumber = (paymentTypePage ?? 1);
            dynamicItems.ApartmentFacilityViewModel = iApartmentFacilityRepository.GetAll().ToPagedList(facilityPageNumber, pageSize);
            dynamicItems.ApartmentTypeViewModel = iApartmentTypeRepository.GetAll().ToPagedList(typePageNumber, pageSize);
            dynamicItems.BookingStatusViewModel = iBookingStatusRepository.GetAll().ToPagedList(statusPageNumber, pageSize);
            dynamicItems.PaymentTypeViewModel = iPaymentTypeRepository.GetAll().ToPagedList(paymentTypePageNumber, pageSize);
            return View(dynamicItems);
        }


        [HttpPost]
        public IActionResult TypeCreate(ApartmentTypeViewModel obj, int? facilityPage, int? typePage, int? bookingStatusPage, int? paymentTypePage)
        {
            if (ModelState.IsValid)
            {
                iApartmentTypeRepository.Insert(obj);
            }
            dynamic dynamicItems = new ExpandoObject();
            int facilityPageNumber = (facilityPage ?? 1);
            int typePageNumber = (typePage ?? 1);
            int statusPageNumber = (bookingStatusPage ?? 1);
            int paymentTypePageNumber = (paymentTypePage ?? 1);
            dynamicItems.ApartmentFacilityViewModel = iApartmentFacilityRepository.GetAll().ToPagedList(facilityPageNumber, pageSize);
            dynamicItems.ApartmentTypeViewModel = iApartmentTypeRepository.GetAll().ToPagedList(typePageNumber, pageSize);
            dynamicItems.BookingStatusViewModel = iBookingStatusRepository.GetAll().ToPagedList(statusPageNumber, pageSize);
            dynamicItems.PaymentTypeViewModel = iPaymentTypeRepository.GetAll().ToPagedList(paymentTypePageNumber, pageSize);
            return PartialView("_ApartmentTypeList", dynamicItems);
        }
        [HttpGet]
        public PartialViewResult TypeEdit(int id)
        {
            ApartmentTypeViewModel obj = iApartmentTypeRepository.GetById(id);
            return PartialView("~/Areas/User/Views/AccessoryItems/_TypeEdit.cshtml", obj);
        }

        [HttpPost]
        public IActionResult TypeEdit(ApartmentTypeViewModel objModel)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
                if (objModel.AptTypeCode > 0)
                {
                    iApartmentTypeRepository.Update(objModel);
                    result = true;
                }

            }

            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Appartment type is not Edited"; 
                return RedirectToAction("Message", "Error", new { area = "" });
            }
        }
        public IActionResult TypeDelete(int id)
        {
            if (id>0)
            {
                iApartmentTypeRepository.Delete(id);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult BookingStatusCreate(BookingStatusViewModel obj, int? facilityPage, int? typePage, int? bookingStatusPage, int? paymentTypePage)
        {
            if (ModelState.IsValid)
            {
                iBookingStatusRepository.Insert(obj);
            }
            dynamic dynamicItems = new ExpandoObject();
            int facilityPageNumber = (facilityPage ?? 1);
            int typePageNumber = (typePage ?? 1);
            int statusPageNumber = (bookingStatusPage ?? 1);
            int paymentTypePageNumber = (paymentTypePage ?? 1);
            dynamicItems.ApartmentFacilityViewModel = iApartmentFacilityRepository.GetAll().ToPagedList(facilityPageNumber, pageSize);
            dynamicItems.ApartmentTypeViewModel = iApartmentTypeRepository.GetAll().ToPagedList(typePageNumber, pageSize);
            dynamicItems.BookingStatusViewModel = iBookingStatusRepository.GetAll().ToPagedList(statusPageNumber, pageSize);
            dynamicItems.PaymentTypeViewModel = iPaymentTypeRepository.GetAll().ToPagedList(paymentTypePageNumber, pageSize);
            return PartialView("_BookingStatusList", dynamicItems);
        }
        [HttpGet]
        public PartialViewResult FacilityEdit(int id)
        {
            ApartmentFacilityViewModel obj = iApartmentFacilityRepository.GetById(id);
            return PartialView("~/Areas/User/Views/AccessoryItems/_FacilityEdit.cshtml", obj);
        }

        [HttpPost]
        public IActionResult FacilityEdit(ApartmentFacilityViewModel objModel)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
                if (objModel.FacilityCode > 0)
                {
                    iApartmentFacilityRepository.Update(objModel);
                    result = true;
                }

            }

            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Appartment facility is not Edited"; 
                return RedirectToAction("Message", "Error", new { area = "" });
            }
        }
        public IActionResult FacilityDelete(int id)
        {
            if (id>0)
            {
                iApartmentFacilityRepository.Delete(id);
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult FacilityCreate(ApartmentFacilityViewModel obj, int? facilityPage, int? typePage, int? bookingStatusPage, int? paymentTypePage)
        {
            if (ModelState.IsValid)
            {
                iApartmentFacilityRepository.Insert(obj);
            }
            dynamic dynamicItems = new ExpandoObject();
            int facilityPageNumber = (facilityPage ?? 1);
            int typePageNumber = (typePage ?? 1);
            int statusPageNumber = (bookingStatusPage ?? 1);
            int paymentTypePageNumber = (paymentTypePage ?? 1);
            dynamicItems.ApartmentFacilityViewModel = iApartmentFacilityRepository.GetAll().ToPagedList(facilityPageNumber, pageSize);
            dynamicItems.ApartmentTypeViewModel = iApartmentTypeRepository.GetAll().ToPagedList(typePageNumber, pageSize);
            dynamicItems.BookingStatusViewModel = iBookingStatusRepository.GetAll().ToPagedList(statusPageNumber, pageSize);
            dynamicItems.PaymentTypeViewModel = iPaymentTypeRepository.GetAll().ToPagedList(paymentTypePageNumber, pageSize);
            return PartialView("_FacilityList", dynamicItems);
        }

        [HttpGet]
        public PartialViewResult StatusEdit(int id)
        {
            BookingStatusViewModel obj = iBookingStatusRepository.GetById(id);
            return PartialView("~/Areas/User/Views/AccessoryItems/_StatusEdit.cshtml", obj);
        }

        [HttpPost]
        public IActionResult StatusEdit(BookingStatusViewModel objModel)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
                if (objModel.BookingStatusCode > 0)
                {
                    iBookingStatusRepository.Update(objModel);
                    result = true;
                }

            }

            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Booking Status is not Edited"; 
                return RedirectToAction("Message", "Error", new { area = "" });
            }
        }
        public IActionResult StatusDelete(int id)
        {
            if (id > 0)
            {
                iBookingStatusRepository.Delete(id);
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult PaymentTypeCreate(PaymentTypeViewModel obj, int? facilityPage, int? typePage, int? bookingStatusPage, int? paymentTypePage)
        {
            if (ModelState.IsValid)
            {
                iPaymentTypeRepository.Insert(obj);
            }
            dynamic dynamicItems = new ExpandoObject();
            int facilityPageNumber = (facilityPage ?? 1);
            int typePageNumber = (typePage ?? 1);
            int statusPageNumber = (bookingStatusPage ?? 1);
            int paymentTypePageNumber = (paymentTypePage ?? 1);
            dynamicItems.ApartmentFacilityViewModel = iApartmentFacilityRepository.GetAll().ToPagedList(facilityPageNumber, pageSize);
            dynamicItems.ApartmentTypeViewModel = iApartmentTypeRepository.GetAll().ToPagedList(typePageNumber, pageSize);
            dynamicItems.BookingStatusViewModel = iBookingStatusRepository.GetAll().ToPagedList(statusPageNumber, pageSize);
            dynamicItems.PaymentTypeViewModel = iPaymentTypeRepository.GetAll().ToPagedList(paymentTypePageNumber, pageSize);
            return PartialView("_PaymentTypeList", dynamicItems);
        }

        [HttpGet]
        public PartialViewResult PaymentTypeEdit(int id)
        {
            PaymentTypeViewModel obj = iPaymentTypeRepository.GetById(id);
            return PartialView("~/Areas/User/Views/AccessoryItems/_PaymentTypeEdit.cshtml", obj);
        }

        [HttpPost]
        public IActionResult PaymentTypeEdit(PaymentTypeViewModel objModel)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
                if (objModel.PaymentTypeId > 0)
                {
                    iPaymentTypeRepository.Update(objModel);
                    result = true;
                }

            }

            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Booking Status is not Edited";
                return RedirectToAction("Message", "Error", new { area = "" });
            }
        }
        public IActionResult PaymentTypeDelete(int id)
        {
            if (id > 0)
            {
                iPaymentTypeRepository.Delete(id);
            }
            return RedirectToAction("Index");
        }
    }
}
