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

namespace HouseRentalManagementSystem.Controllers
{
    [Authorize]
    public class ApartmentBuildingController : Controller
    {
        private readonly IBuildingRepository iBuildingRepository;
        private readonly IWebHostEnvironment iWebHostEnvironment;
        public ApartmentBuildingController(IBuildingRepository _iBuildingRepository, IWebHostEnvironment _iWebHostEnvironment)
        {
            iWebHostEnvironment = _iWebHostEnvironment;
            iBuildingRepository = _iBuildingRepository;
        }
        public IActionResult Index(string SearchString, string CurrentFilter, string SortOrder, int? page)
        {
            if(SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = CurrentFilter;
            }
            ViewBag.SortNameParam = string.IsNullOrEmpty(SortOrder) ? "name_desc" : "";
            ViewBag.CurrentFilter = SearchString;
            IEnumerable<ApartmentBuildingViewModel> itemList = iBuildingRepository.GetAll();
            int indexNumber = 0;
            foreach (var item in itemList)
            {
               item.SirialNumber = indexNumber += 1;

            }
            if(!string.IsNullOrEmpty(SearchString))
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
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApartmentBuildingViewModelMultipleInsert objModel, IFormFile[] ImageName)
        {
            if (ModelState.IsValid)
            {
                string uniqueImageName = null;
                if (ImageName != null)
                {
                    if (objModel.ApartmentBuildingViewModels.Count == ImageName.Count())
                    {
                        for (int i = 0; i < objModel.ApartmentBuildingViewModels.Count; i++)
                        {
                            if (ImageName[i] != null)
                            {
                                string uploadFolder = Path.Combine(iWebHostEnvironment.WebRootPath, "images/building_images");
                                uniqueImageName = Guid.NewGuid().ToString() + "_" + ImageName[i].FileName;
                                string filePath = Path.Combine(uploadFolder, uniqueImageName); 
                                FileStream fileStream = new FileStream(filePath, FileMode.Create);
                                ImageName[i].CopyTo(fileStream);
                                fileStream.Close();
                                objModel.ApartmentBuildingViewModels[i].ImageName = uniqueImageName;
                                iBuildingRepository.Insert(objModel.ApartmentBuildingViewModels[i]);
                            }

                        }
                    }
                }
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Building  is not Added";
                return RedirectToAction("Message", "Error", new { area = "" });
            }

        }
        [HttpGet]
        public PartialViewResult Edit(int id)
        {
            ApartmentBuildingViewModel obj = iBuildingRepository.GetById(id);
            ViewBag.Details = "Show";
            return PartialView("~/Areas/User/Views/ApartmentBuilding/_Edit.cshtml", obj);
        }
        //public IActionResult Edit(int id)
        //{
        //    ViewBag.Details = "Show";
        //    ApartmentBuildingViewModel building = iBuildingRepository.GetById(id);
        //    return View(building);
        //}
        [HttpPost]
        public IActionResult Edit(ApartmentBuildingViewModel objModel)
        {
            string uniqueImageName = null;
            bool result = false;
            if (ModelState.IsValid)
            {
                if (objModel.BuildingId > 0)
                {
                    if (objModel.Photo != null)
                    {
                        string uploadFolder = Path.Combine(iWebHostEnvironment.WebRootPath, "images/building_images");
                        DeleteExistingImage(Path.Combine(uploadFolder, objModel.ImageName));
                        uniqueImageName = Guid.NewGuid().ToString() + "_" + objModel.Photo.FileName;
                        string filePath = Path.Combine(uploadFolder, uniqueImageName);
                        FileStream fileStream = new FileStream(filePath, FileMode.Create);
                        objModel.Photo.CopyTo(fileStream);
                        fileStream.Close();
                        objModel.ImageName = uniqueImageName;
                    }
                    iBuildingRepository.Update(objModel);
                    result = true;
                }
            }

            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ApartmentBuildingViewModel building = iBuildingRepository.GetById(objModel.BuildingId);
                return View(building);
            }
        }

        [HttpGet]
        public PartialViewResult Details(int id)
        {
            ApartmentBuildingViewModel obj = iBuildingRepository.GetById(id);
            ViewBag.Details = "Show";
            return PartialView("~/Areas/User/Views/ApartmentBuilding/_Details.cshtml", obj);
        }
        public PartialViewResult ShowImage(int id)
        {
            ApartmentBuildingViewModel obj = iBuildingRepository.GetById(id);
            ViewBag.Details = "Show";
            return PartialView("~/Areas/User/Views/ApartmentBuilding/_ShowImage.cshtml", obj);
        }
        
        public IActionResult Delete(int id)
        {
            var building = iBuildingRepository.GetById(id);
            if (building.ImageName != null)
            {
                string uploadFolder = Path.Combine(iWebHostEnvironment.WebRootPath, "images/building_images");
                DeleteExistingImage(Path.Combine(uploadFolder, building.ImageName));
            }
            iBuildingRepository.Delete(building.BuildingId);
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
