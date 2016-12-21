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

namespace web.BloodDonerManagement.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            DotNet.Highcharts.Highcharts chart = new DotNet.Highcharts.Highcharts("chart")
         .SetXAxis(new XAxis
         {
             Categories = new[] { "0+", "0-", "A+", "A-", "B+", "B-", "AB+", "AB-" }
         })
         .SetSeries(new Series
         {
             Name = "Raporti i gjakut",
             Type = ChartTypes.Pie,
             Data = new Data(new object[] { 29.9, 71.5, 106.4, 129.2, 144.0, 176.0, 135.6, 148.5 })
         });

            return View(chart);
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
        //public ActionResult CharacterColumn()
        //{
        //    ArrayList xValue = new ArrayList();
        //    ArrayList yValue = new ArrayList();

        //    var results = (from c in db.Patient select c);
        //    results.ToList().ForEach(rs => xValue.Add(rs.Id));
        //    results.ToList().ForEach(rs => yValue.Add(200));
        //    new Chart(width: 600, height: 400, theme: ChartTheme.Green)
        //        .AddTitle("HEllo from EGzon ARifi")
        //        .AddSeries("Default", chartType: "Pie", xValue: xValue, yValues: yValue)
        //        .Write("bmp");
        //    return null;
        //}
    }
}