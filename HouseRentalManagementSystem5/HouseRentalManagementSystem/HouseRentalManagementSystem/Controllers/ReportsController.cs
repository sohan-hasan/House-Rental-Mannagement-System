using FastReport.Data;
using FastReport.Export.PdfSimple;
using FastReport.Web;
using HouseRentalManagementSystem.IRepository;
using HouseRentalManagementSystem.UserViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace HouseRentalManagementSystem.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IConfiguration iConfiguration;
        private readonly IWebHostEnvironment iWebHostEnvironment;
        private readonly ITenantRepository iTenantRepository;
        private readonly IBookingPaymentRepository iBookingPaymentRepository;
        public ReportsController(IBookingPaymentRepository _iBookingPaymentRepository, ITenantRepository _iTenantRepository, IConfiguration _iConfiguration, IWebHostEnvironment _iWebHostEnvironment)
        {
            iConfiguration = _iConfiguration;
            iWebHostEnvironment = _iWebHostEnvironment;
            iTenantRepository = _iTenantRepository;
            iBookingPaymentRepository = _iBookingPaymentRepository;

        }

        public IActionResult Report()
        {
            var webReport = GetReport();
            ViewBag.WebReport = webReport;
            return View();
        }
        public IActionResult PaymentReport()
        {
            var webReport = GetPaymentReport();
            ViewBag.WebReport = webReport;
            return View();
        }
        public WebReport GetReport()
        {
            var webReport = new WebReport();
            var mssqlDataConnection = new MsSqlDataConnection();
            mssqlDataConnection.ConnectionString = iConfiguration.GetConnectionString("HouseRentalDB");
            webReport.Report.Dictionary.Connections.Add(mssqlDataConnection);
            webReport.Report.Load(Path.Combine(iWebHostEnvironment.ContentRootPath, "Reports", "tenant.frx"));
            var tenants = iTenantRepository.GetAll();
            //string uploadFolder = Path.Combine(iWebHostEnvironment.WebRootPath, "images/tenant_images");
            //foreach (var item in tenants)
            //{
            //    item.ImageName = uploadFolder + item.ImageName;
            //    if (Convert.ToInt16(item.GenderCode) == 0)
            //    {
            //        item.GenderCode = "Female";
            //    }
            //    else
            //    {
            //        item.GenderCode = "Male";
            //    }
            //}
            webReport.Report.RegisterData(tenants, "Tanants");
            return webReport;
        }
        public WebReport GetPaymentReport()
        {
            var webReport = new WebReport();
            var mssqlDataConnection = new MsSqlDataConnection();
            mssqlDataConnection.ConnectionString = iConfiguration.GetConnectionString("HouseRentalDB");
            webReport.Report.Dictionary.Connections.Add(mssqlDataConnection);
            webReport.Report.Load(Path.Combine(iWebHostEnvironment.ContentRootPath, "Reports", "PaymantReport.frx"));
            var payment = iBookingPaymentRepository.GetAll();
            //string uploadFolder = Path.Combine(iWebHostEnvironment.WebRootPath, "images/tenant_images");
            //foreach (var item in tenants)
            //{
            //    item.ImageName = uploadFolder + item.ImageName;
            //    if (Convert.ToInt16(item.GenderCode) == 0)
            //    {
            //        item.GenderCode = "Female";
            //    }
            //    else
            //    {
            //        item.GenderCode = "Male";
            //    }
            //}
            webReport.Report.RegisterData(payment, "BookingPayments");
            return webReport;
        }
        public IActionResult Pdf()
        {
            var webReport = GetReport();
            webReport.Report.Prepare();

            using (MemoryStream ms = new MemoryStream())
            {
                PDFSimpleExport pdfExport = new PDFSimpleExport();
                pdfExport.Export(webReport.Report, ms);
                ms.Flush();
                return File(ms.ToArray(), "application/pdf", Path.GetFileNameWithoutExtension("tenants_info") + ".pdf");
            }
        }
        public IActionResult PdfPaymentReport()
        {
            var webReport = GetPaymentReport();
            webReport.Report.Prepare();

            using (MemoryStream ms = new MemoryStream())
            {
                PDFSimpleExport pdfExport = new PDFSimpleExport();
                pdfExport.Export(webReport.Report, ms);
                ms.Flush();
                return File(ms.ToArray(), "application/pdf", Path.GetFileNameWithoutExtension("paymentReport") + ".pdf");
            }
        }
        //static DataTable GetTable<TEntity>(IEnumerable<TEntity> table, string name) where TEntity : class
        //{
        //    var offset = 78;
        //    DataTable result = new DataTable(name);
        //    PropertyInfo[] infos = typeof(TEntity).GetProperties();
        //    foreach (PropertyInfo info in infos)
        //    {
        //        if (info.PropertyType.IsGenericType
        //        && info.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
        //        {
        //            result.Columns.Add(new DataColumn(info.Name, Nullable.GetUnderlyingType(info.PropertyType)));
        //        }
        //        else
        //        {
        //            result.Columns.Add(new DataColumn(info.Name, info.PropertyType));
        //        }
        //    }
        //    foreach (var el in table)
        //    {
        //        DataRow row = result.NewRow();
        //        foreach (PropertyInfo info in infos)
        //        {
        //            if (info.PropertyType.IsGenericType &&
        //                info.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
        //            {
        //                object t = info.GetValue(el);
        //                if (t == null)
        //                {
        //                    t = Activator.CreateInstance(Nullable.GetUnderlyingType(info.PropertyType));
        //                }

        //                row[info.Name] = t;
        //            }
        //            else
        //            {
        //                if (info.PropertyType == typeof(byte[]))
        //                {
        //                    //Fix for Image issue.
        //                    var imageData = (byte[])info.GetValue(el);
        //                    var bytes = new byte[imageData.Length - offset];
        //                    Array.Copy(imageData, offset, bytes, 0, bytes.Length);
        //                    row[info.Name] = bytes;
        //                }
        //                else
        //                {
        //                    row[info.Name] = info.GetValue(el);
        //                }
        //            }
        //        }
        //        result.Rows.Add(row);
        //    }

        //    return result;
        //}
    }
}
