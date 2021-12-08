using HouseRentalManagementSystem.IRepository;
using HouseRentalManagementSystem.UserViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
    public class TenantController : Controller
    {
        private readonly IWebHostEnvironment iWebHostEnvironment;
        private readonly ITenantRepository iTenantRepository;
        public TenantController(ITenantRepository _iTenantRepository, IWebHostEnvironment _iWebHostEnvironment)
        {
            iTenantRepository = _iTenantRepository;
            iWebHostEnvironment = _iWebHostEnvironment;
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
            IEnumerable<TenantViewModel> itemList = iTenantRepository.GetAll();
            int indexNumber = 0;
            foreach (var item in itemList)
            {
                item.SirialNumber = indexNumber += 1;
                if (Convert.ToInt16(item.GenderCode) == 0)
                {
                    item.GenderProperty = "Female";
                }
                else
                {
                    item.GenderProperty = "Male";
                }

            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                itemList = itemList.Where(e => e.TenantFullName.ToUpper().Contains(SearchString.ToUpper())).ToList();
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
        public IActionResult Create(TenantViewModel objModel)
        {
            string uniqueImageName = null;
            bool result = false;
            if (Convert.ToInt16(objModel.GenderCreate) == 0)
            {
                objModel.GenderCode = "0";
            }
            else
            {
                objModel.GenderCode = "1";
            }
            if (ModelState.IsValid)
            {
                if (objModel.Photo != null)
                {
                    string uploadFolder = Path.Combine(iWebHostEnvironment.WebRootPath, "images/tenant_images");
                    string uploadFolder1 = Path.Combine(iWebHostEnvironment.WebRootPath, "images/tenant_images/");
                    uniqueImageName = Guid.NewGuid().ToString() + "_" + objModel.Photo.FileName;
                    string filePath = Path.Combine(uploadFolder, uniqueImageName);
                    FileStream fileStream = new FileStream(filePath, FileMode.Create);
                    objModel.Photo.CopyTo(fileStream);
                    fileStream.Close();
                    objModel.ImageFullPath = uploadFolder1 + uniqueImageName;
                    objModel.ImageName = uniqueImageName;
                }
                iTenantRepository.Insert(objModel);
                result = true;
            }

            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message="Tenant is not save";
                return RedirectToAction("Message");
            }
        }
        [HttpGet]
        public PartialViewResult Edit(int id)
        {
            ViewBag.Details = "Show";
            TenantViewModel tenant = iTenantRepository.GetById(id);
            return PartialView("~/Areas/User/Views/Tenant/_Edit.cshtml", tenant);
        }
        [HttpPost]
        public IActionResult Edit(TenantViewModel objModel)
        {
            string uniqueImageName = null;
            bool result = false; 
            if (Convert.ToInt16(objModel.GenderCode) == 0)
            {
                objModel.GenderCode = "0";
            }
            else
            {
                objModel.GenderCode = "1";
            }
            if (ModelState.IsValid)
            {
                if (objModel.TenantId > 0)
                {
                    if (objModel.Photo != null)
                    {
                        string uploadFolder = Path.Combine(iWebHostEnvironment.WebRootPath, "images/tenant_images");
                        string uploadFolder1 = Path.Combine(iWebHostEnvironment.WebRootPath, "images/tenant_images/");
                        DeleteExistingImage(Path.Combine(uploadFolder, objModel.ImageName));
                        uniqueImageName = Guid.NewGuid().ToString() + "_" + objModel.Photo.FileName;
                        string filePath = Path.Combine(uploadFolder, uniqueImageName);
                        FileStream fileStream = new FileStream(filePath, FileMode.Create);
                        objModel.Photo.CopyTo(fileStream);
                        fileStream.Close();
                        objModel.ImageFullPath = uploadFolder1 + uniqueImageName;
                        objModel.ImageName = uniqueImageName;
                    }
                    iTenantRepository.Update(objModel);
                    result = true;
                }
            }

            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Tenant is not Edited";
                return RedirectToAction("Message");
            }
        }
        [HttpGet] 
        public IActionResult Details(int id)
        {
            ViewBag.Details = "Show";
            TenantViewModel tenant = iTenantRepository.GetById(id);
            if (Convert.ToInt16(tenant.GenderCode) == 0)
            {
                tenant.GenderProperty = "Female";
            }
            else
            {
                tenant.GenderProperty = "Male";
            }

            return PartialView("~/Areas/User/Views/Tenant/_Details.cshtml", tenant);
        }
        public IActionResult ShowImage(int id)
        {
            ViewBag.Details = "Show";
            TenantViewModel tenant = iTenantRepository.GetById(id);
            if (Convert.ToInt16(tenant.GenderCode) == 0)
            {
                tenant.GenderProperty = "Female";
            }
            else
            {
                tenant.GenderProperty = "Male";
            }

            return PartialView("~/Areas/User/Views/Tenant/_ShowImage.cshtml", tenant);
        }
        public IActionResult Delete(int id)
        {
            TenantViewModel obj = iTenantRepository.GetById(id);
            if (obj.ImageName != null)
            {
                string uploadFolder = Path.Combine(iWebHostEnvironment.WebRootPath, "images/tenant_images");
                DeleteExistingImage(Path.Combine(uploadFolder, obj.ImageName));
            }
            iTenantRepository.Delete(obj.TenantId);
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
