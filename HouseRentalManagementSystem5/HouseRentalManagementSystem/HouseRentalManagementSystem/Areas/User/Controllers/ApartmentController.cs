using HouseRentalManagementSystem.IRepository;
using HouseRentalManagementSystem.UserViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace HouseRentalManagementSystem.Areas.User.Controllers
{
    [Authorize]
    public class ApartmentController : Controller
    {
        private readonly IApartmentRepository iApartmentRepository;
        private readonly IBuildingRepository iBuildingRepository;
        private readonly IApartmentTypeRepository iApartmentTypeRepository;
        private readonly IApartmentImageRepository iApartmentImageRepository;
        private readonly IWebHostEnvironment iWebHostEnvironment;
        private readonly IApartmentFacilityRepository iApartmentFacilityRepository;
        private readonly IApartmentWiseFacilityRepository iApartmentWiseFacilityRepository;
        public ApartmentController(IApartmentWiseFacilityRepository _iApartmentWiseFacilityRepository,IApartmentRepository _iApartmentRepository, IWebHostEnvironment _iWebHostEnvironment, IBuildingRepository _iBuildingRepository, IApartmentTypeRepository _iApartmentTypeRepository, IApartmentImageRepository _iApartmentImageRepository, IApartmentFacilityRepository _iApartmentFacilityRepository)
        {
            iWebHostEnvironment = _iWebHostEnvironment;
            iApartmentRepository = _iApartmentRepository;
            iBuildingRepository = _iBuildingRepository;
            iApartmentTypeRepository = _iApartmentTypeRepository;
            iApartmentImageRepository = _iApartmentImageRepository;
            iApartmentFacilityRepository = _iApartmentFacilityRepository;
            iApartmentWiseFacilityRepository = _iApartmentWiseFacilityRepository;
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
            ViewBag.Building = iBuildingRepository.GetAll();
            ViewBag.Types = iApartmentTypeRepository.GetAll();
            ViewBag.Facilities = iApartmentFacilityRepository.GetAll();
            IEnumerable<ApartmentViewModel> itemList = iApartmentRepository.GetAll();
            int indexNumber = 0;
            foreach (var item in itemList)
            {
                item.SirialNumber = indexNumber += 1;

            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                itemList = itemList.Where(e => e.BuildingShortName.ToUpper().Contains(SearchString.ToUpper())).ToList();
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
        [HttpPost]
        public IActionResult Create(ApartmentViewModel objModel)
        {
            string uniqueImageName = null;
            bool result = false;
            if (ModelState.IsValid)
            {
                if (objModel.AptId > 0)
                {
                    ViewBag.ErrorMessage = "Apartment is not Added"; 
                    return RedirectToAction("Message", "Error", new { area = "" });
                }
                else
                {
                    ApartmentViewModel returnObj = iApartmentRepository.Insert(objModel);
                    ApartmentImageViewModel imageObj = new ApartmentImageViewModel();
                    ApartmentWiseFacilityViewModel facilityObj = new ApartmentWiseFacilityViewModel();
                    if (objModel.Photos != null && objModel.Photos.Count > 0)
                    {
                        foreach (IFormFile photo in objModel.Photos)
                        {
                            string uploadFolder = Path.Combine(iWebHostEnvironment.WebRootPath, "images/apartment_images");
                            uniqueImageName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                            string filePath = Path.Combine(uploadFolder, uniqueImageName);
                            FileStream fileStream = new FileStream(filePath, FileMode.Create);
                            photo.CopyTo(fileStream);
                            fileStream.Close();
                            imageObj.AptId = returnObj.AptId;
                            imageObj.ImageName = uniqueImageName;
                            iApartmentImageRepository.Insert(imageObj);
                        }
                    }
                    if (objModel.FacilityCode != null && objModel.FacilityCode.Length > 0)
                    {
                        var Facilities = iApartmentFacilityRepository.GetAll();
                        foreach (ApartmentFacilityViewModel fac in Facilities)
                        {
                            int fac_val = fac.FacilityCode;
                            int k = 0;
                            for (int j = 0; j < objModel.FacilityCode.Length; j++)
                            {
                                int selected_fac_val = objModel.FacilityCode[j];
                                if (fac_val== selected_fac_val)
                                {
                                    k = 1;
                                }
                            }
                            if(k==0)
                            {
                                facilityObj.AptId = returnObj.AptId;
                                facilityObj.FacilityCode = fac.FacilityCode;
                                facilityObj.IsChecked = false;
                                iApartmentWiseFacilityRepository.Insert(facilityObj);
                            } else if(k==1)
                            {

                                facilityObj.AptId = returnObj.AptId;
                                facilityObj.FacilityCode = fac.FacilityCode;
                                facilityObj.IsChecked = true;
                                iApartmentWiseFacilityRepository.Insert(facilityObj);
                            }
                        }
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
                ViewBag.Message = "Appartment is not save"; 
                return RedirectToAction("Message", "Error", new { area = "" });
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Building = iBuildingRepository.GetAll();
            ViewBag.Types = iApartmentTypeRepository.GetAll();
            ViewBag.Images = iApartmentImageRepository.GetAllByApartmentId(id);
            ViewBag.Facilities = iApartmentWiseFacilityRepository.GetAllByApartmentId(id);
            ApartmentViewModel obj = iApartmentRepository.GetById(id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult Edit(ApartmentViewModel objModel)
        {
            string uniqueImageName = null;
            bool result = false;
            if (ModelState.IsValid)
            {
                if (objModel.AptId > 0)
                {
                    ApartmentViewModel returnObj = iApartmentRepository.Update(objModel);
                    ApartmentImageViewModel imageObj = new ApartmentImageViewModel();
                    ApartmentWiseFacilityViewModel facilityObj = new ApartmentWiseFacilityViewModel();
                    if (objModel.Edit_Photos != null && objModel.Edit_Photos.Count > 0)
                    {
                        foreach (IFormFile photo in objModel.Edit_Photos)
                        {
                            string uploadFolder = Path.Combine(iWebHostEnvironment.WebRootPath, "images/apartment_images");
                            uniqueImageName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                            string filePath = Path.Combine(uploadFolder, uniqueImageName);
                            FileStream fileStream = new FileStream(filePath, FileMode.Create);
                            photo.CopyTo(fileStream);
                            fileStream.Close();
                            imageObj.AptId = returnObj.AptId;
                            imageObj.ImageName = uniqueImageName;
                            iApartmentImageRepository.Insert(imageObj);
                        }
                    }

                    if (objModel.FacilityCode != null && objModel.FacilityCode.Length > 0)
                    {
                        var facilitiesByApartmentId = iApartmentWiseFacilityRepository.GetAllByApartmentId(returnObj.AptId);
                        foreach (var apartmentWiseFacility in facilitiesByApartmentId)
                        {
                            iApartmentWiseFacilityRepository.Delete(apartmentWiseFacility.ApartmentWiseFacilityId);
                        }
                        var Facilities = iApartmentFacilityRepository.GetAll();
                        foreach (ApartmentFacilityViewModel fac in Facilities)
                        {
                            int fac_val = fac.FacilityCode;
                            int k = 0;
                            for (int j = 0; j < objModel.FacilityCode.Length; j++)
                            {
                                int selected_fac_val = objModel.FacilityCode[j];
                                if (fac_val == selected_fac_val)
                                {
                                    k = 1;
                                }
                            }
                            if (k == 0)
                            {
                                facilityObj.AptId = returnObj.AptId;
                                facilityObj.FacilityCode = fac.FacilityCode;
                                facilityObj.IsChecked = false;
                                iApartmentWiseFacilityRepository.Insert(facilityObj);
                            }
                            else if (k == 1)
                            {

                                facilityObj.AptId = returnObj.AptId;
                                facilityObj.FacilityCode = fac.FacilityCode;
                                facilityObj.IsChecked = true;
                                iApartmentWiseFacilityRepository.Insert(facilityObj);
                            }
                        }
                    }
                    result = true;
                }
                //if (objModel.Photo != null)
                //{
                //    string uploadFolder = Path.Combine(iWebHostEnvironment.WebRootPath, "images/product_images");
                //    uniqueImageName = Guid.NewGuid().ToString() + "_" + objModel.Photo.FileName;
                //    string filePath = Path.Combine(uploadFolder, uniqueImageName);
                //    objModel.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                //    objModel.ImageName = uniqueImageName;
                //}

            }

            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Appartment is not Edited";
                return RedirectToAction("Message");
            }
        }
        public PartialViewResult Details(int id)
        {
            ViewBag.Building = iBuildingRepository.GetAll();
            ViewBag.Types = iApartmentTypeRepository.GetAll();
            ViewBag.Images = iApartmentImageRepository.GetAllByApartmentId(id);
            ViewBag.Facilities = iApartmentWiseFacilityRepository.GetAllByApartmentId(id);
            ApartmentViewModel obj = iApartmentRepository.GetById(id);
            return PartialView("~/Areas/User/Views/Apartment/_Details.cshtml", obj);

        }
        public PartialViewResult ViewImages(int id)
        {
            IEnumerable<ApartmentImageViewModel> obj = iApartmentImageRepository.GetAllByApartmentId(id);
            ViewBag.ViewImages = "Show";
            return PartialView("~/Areas/User/Views/Apartment/_ViewImages.cshtml", obj);
        }
        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                var Images = iApartmentImageRepository.GetAllByApartmentId(id);
                if (Images != null)
                {
                    foreach (var image in Images)
                    {
                        if (image.ImageName != null)
                        {
                            string uploadFolder = Path.Combine(iWebHostEnvironment.WebRootPath, "images/apartment_images");
                            DeleteExistingImage(Path.Combine(uploadFolder, image.ImageName));
                        }
                        iApartmentImageRepository.Delete(image.ImageId);
                    }
                }
                iApartmentRepository.Delete(id);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Apartment not deleted";
                return RedirectToAction("Message");
            }
        }
        public IActionResult DeleteImage(int id)
        {
            var image = iApartmentImageRepository.GetById(id);
            if (image.ImageName != null)
            {
                string uploadFolder = Path.Combine(iWebHostEnvironment.WebRootPath, "images/apartment_images");
                DeleteExistingImage(Path.Combine(uploadFolder, image.ImageName));
            }
            iApartmentImageRepository.Delete(image.ImageId);
            return RedirectToAction("Edit", new { id = image.AptId });
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
