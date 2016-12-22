using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.BloodDonerManagement.Models;

namespace web.BloodDonerManagement.Controllers
{
    public class BloodStockController : BaseController
    {
        // GET: BloodStock
        public ActionResult Index()
        {
            List<BloodStockViewModel> model = db.BloodStock
                .GroupBy(l => l.Patient.BloodType)
                .Select(m => new BloodStockViewModel
            {
                Id = m.FirstOrDefault().Id,
                Patient = m.FirstOrDefault().Patient.Name + " " + m.FirstOrDefault().Patient.Lastname,
                BloodType = m.FirstOrDefault().Patient.BloodType.ToString(),
                BloodQuantity = m.Sum(c => c.BloodQuantity),
                DonateDate = m.FirstOrDefault().DonateDate,
                Comment = m.FirstOrDefault().Comment
            }).ToList();
            return View(model);
        }
        public ActionResult addOrUpdate()
        {
            return View("Create");
        }
        [HttpPost]
        public JsonResult PatientSearch(string Prefix)
        {
            //Note : you can bind same list from database  
            List<BloodStockViewModel> ObjList = new List<BloodStockViewModel>()
            {

                new BloodStockViewModel {Id=1,Patient="Latur" },
                new BloodStockViewModel {Id=2,Patient="Mumbai" },
                new BloodStockViewModel {Id=3,Patient="Pune" },
                new BloodStockViewModel {Id=4,Patient="Delhi" },
                new BloodStockViewModel {Id=5,Patient="Dehradun" },
                new BloodStockViewModel {Id=6,Patient="Noida" },
                new BloodStockViewModel {Id=7,Patient="New Delhi" }

        };
            //Searching records from list using LINQ query  
            var CityName = (from N in ObjList
                            where N.Patient.StartsWith(Prefix)
                            select new { N.Patient });
            return Json(CityName, JsonRequestBehavior.AllowGet);
        }
    }
}