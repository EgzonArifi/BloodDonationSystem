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
                BloodQuantity = m.Sum(c => c.BloodQuantity),
                DonateDate = m.FirstOrDefault().DonateDate,
                Comment = m.FirstOrDefault().Comment
            }).ToList();
            return View(model);
        }
    }
}