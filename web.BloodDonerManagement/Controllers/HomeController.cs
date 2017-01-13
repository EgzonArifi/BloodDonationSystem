using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using web.BloodDonerManagement.Models;

namespace web.BloodDonerManagement.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult StockReports()
        {
            List<BloodStockReportViewModel> result = db.BloodStock
                 .GroupBy(l => l.Patient.BloodType)
                 .Select(cl => new BloodStockReportViewModel
                 {
                     BloodType = cl.FirstOrDefault().Patient.BloodType.ToString(),
                     BloodQuantity = cl.Sum(c => c.BloodQuantity),
                    }).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}