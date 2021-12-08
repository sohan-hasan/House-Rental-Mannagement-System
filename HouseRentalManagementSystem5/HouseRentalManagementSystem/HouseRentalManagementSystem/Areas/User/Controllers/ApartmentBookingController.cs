using HouseRentalManagementSystem.IRepository;
using HouseRentalManagementSystem.UserViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace HouseRentalManagementSystem.Areas.User.Controllers
{
    [Authorize]
    public class ApartmentBookingController : Controller
    {
        private readonly IApartmentBookingRepository iApartmentBookingRepository;
        private readonly IApartmentRepository iApartmentRepository;
        private readonly IBuildingRepository iBuildingRepository;
        private readonly ITenantRepository iTenantRepository;
        private readonly IBookingStatusRepository iBookingStatusRepository;
        private readonly IPaymentTypeRepository iPaymentTypeRepository;
        private readonly ISecurityDepositRepository iSecurityDepositRepository;
        private readonly IBookingPaymentRepository iBookingPaymentRepository;
        private readonly IViewUnitStatusRepository iViewUnitStatusRepository;
        public ApartmentBookingController(IApartmentBookingRepository _iApartmentBookingRepository, IApartmentRepository _iApartmentRepository, IBuildingRepository _iBuildingRepository, ITenantRepository _iTenantRepository, IBookingStatusRepository _iBookingStatusRepository, IPaymentTypeRepository _iPaymentTypeRepository,
            ISecurityDepositRepository _iSecurityDepositRepository, IBookingPaymentRepository _iBookingPaymentRepository, IViewUnitStatusRepository _iViewUnitStatusRepository)
        {
            iApartmentBookingRepository = _iApartmentBookingRepository;
            iApartmentRepository = _iApartmentRepository;
            iBuildingRepository = _iBuildingRepository;
            iTenantRepository = _iTenantRepository;
            iBookingStatusRepository = _iBookingStatusRepository;
            iPaymentTypeRepository = _iPaymentTypeRepository;
            iSecurityDepositRepository = _iSecurityDepositRepository;
            iBookingPaymentRepository = _iBookingPaymentRepository;
            iViewUnitStatusRepository = _iViewUnitStatusRepository;
        }
        public IActionResult Index(string SearchString, string CurrentFilter, string SortOrder, int? page)
        {
            if (SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = CurrentFilter;
            }
            ViewBag.SortNameParam = string.IsNullOrEmpty(SortOrder) ? "name_desc" : "";
            ViewBag.CurrentFilter = SearchString;
            //ViewBag.Buildings = iBuildingRepository.GetAll();
            //ViewBag.Apartments = iApartmentRepository.GetAll();
            //ViewBag.Tenants = iTenantRepository.GetAll();
            //ViewBag.BookingStatuses = iBookingStatusRepository.GetAll();
            IEnumerable<ApartmentBookingViewModel> itemList = iApartmentBookingRepository.GetAll();
            int indexNumber = 0;
            foreach (var item in itemList)
            {
                item.SirialNumber = indexNumber += 1;

            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                itemList = itemList.Where(e => e.BookingStartDate.ToString().Contains(SearchString.ToString())).ToList();
            }
            switch (SortOrder)
            {
                case "name_desc":
                    itemList = itemList.OrderByDescending(e => e.SirialNumber).ToList();
                    break;
                default:
                    itemList = itemList.OrderBy(e => e.SirialNumber).ToList();
                    break;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(itemList.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public PartialViewResult Create()
        {
            ViewBag.Details = "Show";
            ViewBag.Buildings = iBuildingRepository.GetAll();
            ViewBag.Apartments = iApartmentRepository.GetAll();
            ViewBag.Tenants = iTenantRepository.GetAll();
            ViewBag.BookingStatuses = iBookingStatusRepository.GetAll();
            ApartmentBookingViewModel obj = new ApartmentBookingViewModel();
            return PartialView("~/Areas/User/Views/ApartmentBooking/_Create.cshtml", obj);
        }
        [HttpPost]
        public IActionResult Create(ApartmentBookingViewModel objModel)
        {
            bool result = false;
            if (objModel.PaymentTypeId > 0)
            {
                if (ModelState.IsValid)
                {
                    objModel.BookingStatusCode = 1;
                    ApartmentBookingViewModel returnObj = iApartmentBookingRepository.Insert(objModel);
                    if (returnObj.AptBookingId>0)
                    {
                        ViewUnitStatusViewModel objUnitStatus = new ViewUnitStatusViewModel
                        {
                            AptBookingId = returnObj.AptBookingId,
                            AptId=objModel.AptId,
                            StatusDate = DateTime.Now,
                            AvailableYn="NO",
                        };
                        BookingPaymentViewModel objPayment = new BookingPaymentViewModel
                        {
                            PaymentTypeId = objModel.PaymentTypeId,
                            PaymentDate = objModel.PaymentDate,
                            PaymemtAmount=objModel.PaymemtAmount,
                            AptBookingId=returnObj.AptBookingId,
                        };
                        SecurityDepositViewModel objDeposit = new SecurityDepositViewModel
                        {
                            ReturnDate = objModel.ReturnDate,
                            DepositAmount = objModel.SecurityDepositAmount,
                            AptBookingId= returnObj.AptBookingId,
                        };
                        iViewUnitStatusRepository.Insert(objUnitStatus);
                        iBookingPaymentRepository.Insert(objPayment);
                        iSecurityDepositRepository.Insert(objDeposit);
                    }
                    result = true;

                }
            }
            else
            {
                ModelState.Remove("ReturnDate");
                ModelState.Remove("PaymentTypeId");
                ModelState.Remove("PaymentDate");
                if (ModelState.IsValid)
                {
                    objModel.BookingStatusCode = 2;
                    ApartmentBookingViewModel returnObj = iApartmentBookingRepository.Insert(objModel);
                    if (returnObj.AptBookingId > 0)
                    {
                        ViewUnitStatusViewModel objUnitStatus = new ViewUnitStatusViewModel
                        {
                            AptBookingId = returnObj.AptBookingId,
                            AptId = objModel.AptId,
                            StatusDate = DateTime.Now,
                            AvailableYn = "YES",
                        };
                        iViewUnitStatusRepository.Insert(objUnitStatus);
                    }
                    result = true;
                }
            }

            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Booking is not save";
                return RedirectToAction("Message", "Error", new { area = "" });
            }
        }
        [HttpGet]
        public PartialViewResult Edit(int id)
        {
            ViewBag.Details = "Show";
            ViewBag.Buildings = iBuildingRepository.GetAll();
            ViewBag.Tenants = iTenantRepository.GetAll();
            ViewBag.BookingStatuses = iBookingStatusRepository.GetAll();
            ViewBag.PaymentTypes = iPaymentTypeRepository.GetAll();
            ApartmentBookingViewModel booking = iApartmentBookingRepository.GetById(id);
            ViewBag.Apartments = iApartmentRepository.GetByBuildingId(booking.BuildingId);
            return PartialView("~/Areas/User/Views/ApartmentBooking/_Edit.cshtml", booking);
        }
        [HttpPost]
        public IActionResult Edit(ApartmentBookingViewModel objModel)
        {
            bool result = false;
            if (objModel.AptBookingId>0)
            {
                if (objModel.PaymentTypeId > 0)
                {
                    ModelState.Remove("ReturnDate");
                    ModelState.Remove("PaymentTypeId");
                    ModelState.Remove("PaymentDate");
                    if (ModelState.IsValid)
                    {
                        objModel.BookingStatusCode = 1;
                        ApartmentBookingViewModel returnObj = iApartmentBookingRepository.Update(objModel);
                        if (returnObj.AptBookingId > 0)
                        {
                            ViewUnitStatusViewModel returnViewUnitStatusObj = iViewUnitStatusRepository.GetViewUnitStatusByBookingId(returnObj.AptBookingId);
                            if (returnViewUnitStatusObj != null)
                            {
                                ViewUnitStatusViewModel objUnitStatus = new ViewUnitStatusViewModel
                                {
                                    StatusId = returnViewUnitStatusObj.StatusId,
                                    AptBookingId = returnObj.AptBookingId,
                                    AptId = objModel.AptId,
                                    StatusDate = DateTime.Now,
                                    AvailableYn = "NO",
                                };
                                iViewUnitStatusRepository.Update(objUnitStatus);
                            }
                            else
                            {
                                ViewUnitStatusViewModel objUnitStatus = new ViewUnitStatusViewModel
                                {
                                    AptBookingId = returnObj.AptBookingId,
                                    AptId = objModel.AptId,
                                    StatusDate = DateTime.Now,
                                    AvailableYn = "NO",
                                };
                                iViewUnitStatusRepository.Insert(objUnitStatus);
                            }
                            BookingPaymentViewModel returnPaymentObj = iBookingPaymentRepository.GetBookingPaymentByBookingId(returnObj.AptBookingId);
                            if (returnPaymentObj!=null)
                            {
                                BookingPaymentViewModel objPayment = new BookingPaymentViewModel
                                {
                                    PaymentId = returnPaymentObj.PaymentId,
                                    PaymentTypeId = objModel.PaymentTypeId,
                                    PaymentDate = objModel.PaymentDate,
                                    PaymemtAmount = objModel.PaymemtAmount,
                                    AptBookingId = returnObj.AptBookingId,
                                };
                                iBookingPaymentRepository.Update(objPayment);
                            }
                            else
                            {
                                BookingPaymentViewModel objPayment = new BookingPaymentViewModel
                                {
                                    PaymentTypeId = objModel.PaymentTypeId,
                                    PaymentDate = objModel.PaymentDate,
                                    PaymemtAmount = objModel.PaymemtAmount,
                                    AptBookingId = returnObj.AptBookingId,
                                };
                                iBookingPaymentRepository.Insert(objPayment);

                            }
                            SecurityDepositViewModel returnDipositObj = iSecurityDepositRepository.GetSecurityDipositeByBookingId(returnObj.AptBookingId);
                            if (returnDipositObj!=null)
                            {
                                SecurityDepositViewModel objDeposit = new SecurityDepositViewModel
                                {
                                    DepositPaymentId = returnDipositObj.DepositPaymentId,
                                    ReturnDate = objModel.ReturnDate,
                                    DepositAmount = objModel.SecurityDepositAmount,
                                    AptBookingId = returnObj.AptBookingId,
                                };
                                iSecurityDepositRepository.Update(objDeposit);
                            }
                            else
                            {
                                SecurityDepositViewModel objDeposit = new SecurityDepositViewModel
                                {
                                    ReturnDate = objModel.ReturnDate,
                                    DepositAmount = objModel.SecurityDepositAmount,
                                    AptBookingId = returnObj.AptBookingId,
                                };
                                iSecurityDepositRepository.Insert(objDeposit);
                            }
                        }
                        result = true;

                    }
                }
                else
                {
                    ModelState.Remove("ReturnDate");
                    ModelState.Remove("PaymentTypeId");
                    ModelState.Remove("PaymentDate");
                    if (ModelState.IsValid)
                    {
                        objModel.BookingStatusCode = 2;
                        ApartmentBookingViewModel returnObj = iApartmentBookingRepository.Update(objModel);
                        if (returnObj.AptBookingId > 0)
                        {
                            ViewUnitStatusViewModel returnViewUnitStatusObj = iViewUnitStatusRepository.GetViewUnitStatusByBookingId(returnObj.AptBookingId);
                            if (returnViewUnitStatusObj!=null)
                            {
                                ViewUnitStatusViewModel objUnitStatus = new ViewUnitStatusViewModel
                                {
                                    StatusId = returnViewUnitStatusObj.StatusId,
                                    AptBookingId = returnObj.AptBookingId,
                                    AptId = objModel.AptId,
                                    StatusDate = DateTime.Now,
                                    AvailableYn = "YES",
                                };
                                iViewUnitStatusRepository.Update(objUnitStatus);
                            }
                        }
                        result = true;
                    }
                }
            }

            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Booking is not save";
                return RedirectToAction("Message", "Error", new { area = "" });
            }
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            ViewBag.Details = "Show";
            ViewBag.Apartments = iApartmentRepository.GetAll();
            ViewBag.Buildings = iBuildingRepository.GetAll();
            ViewBag.Tenants = iTenantRepository.GetAll();
            ViewBag.BookingStatuses = iBookingStatusRepository.GetAll();
            ApartmentBookingViewModel booking = iApartmentBookingRepository.GetById(id);
            return PartialView("~/Areas/User/Views/ApartmentBooking/_Details.cshtml", booking);
        }
        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                ApartmentBookingViewModel returnObj = iApartmentBookingRepository.Delete(id);
                if (returnObj != null)
                {
                    ViewUnitStatusViewModel returnViewUnitStatusObj = iViewUnitStatusRepository.GetViewUnitStatusByBookingId(returnObj.AptBookingId);
                    if (returnViewUnitStatusObj != null)
                    {
                        iBookingStatusRepository.Delete(returnViewUnitStatusObj.StatusId);
                    }
                    BookingPaymentViewModel returnPaymentObj = iBookingPaymentRepository.GetBookingPaymentByBookingId(returnObj.AptBookingId);
                    if (returnPaymentObj != null)
                    {
                        iBookingPaymentRepository.Delete(returnPaymentObj.PaymentId);
                    }
                    SecurityDepositViewModel returnDipositObj = iSecurityDepositRepository.GetSecurityDipositeByBookingId(returnObj.AptBookingId);
                    if (returnDipositObj != null)
                    {
                        iSecurityDepositRepository.Delete(returnDipositObj.DepositPaymentId);
                    }
                }

            }
            return RedirectToAction("Index");
        }
        public JsonResult GetBuilding()
        {
            return Json(iBuildingRepository.GetAll());
        }
        public JsonResult GetByBuildingId(int id)
        {
            return Json(iApartmentRepository.GetByBuildingId(id));
        }
        public JsonResult GetByApartmentId(int id)
        {
            return Json(iApartmentRepository.GetById(id));
        }
        public JsonResult GetAllPaymentType()
        {
            return Json(iPaymentTypeRepository.GetAll());
        }
    }
}
