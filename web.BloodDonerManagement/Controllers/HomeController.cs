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
            DotNet.Highcharts.Highcharts chart = new DotNet.Highcharts.Highcharts("chart")
                .SetTitle(new Title
                {
                    Text = "Raporti i stokut te gjakut",
                    X = -20
                })
         .SetXAxis(new XAxis
         {
             Categories = new[] { "0+", "0-", "A+", "A-", "B+", "B-", "AB+", "AB-" }
         })
         .SetTooltip(new Tooltip
         {
             Enabled = true,
            PointFormat = "{series.name}: <b>{point.percentage:.1f} ml</b>"
         })
         
         .SetSeries(new Series
         {
             Name = "Sasia e gjakut",
             Type = ChartTypes.Pie,
             Data = new Data(new object[] {
                new object[] { "0 Pozitiv", 45 },
                new object[] { "0 Negativ", 24.8 },
                new object[] { "A Pozitiv", 12.8 },
                new object[] { "A Negativ", 8.5 },
                new object[] { "B Pozitiv", 5.2 },
                new object[] { "B Negativ", 3.7 },
                new object[] { "AB Pozitive", 35.2 },
                new object[] { "AB Negativ", 23.7 }
            })
         }
         );
            return View(chart);
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