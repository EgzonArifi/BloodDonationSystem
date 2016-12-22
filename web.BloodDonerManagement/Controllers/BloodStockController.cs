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
            List<BloodStockViewModel> model = db.BloodStock.Select(m => new BloodStockViewModel
            {
                Id = m.Id,
                Patient = m.Patient.Name + " " + m.Patient.Lastname,
                BloodQuantity = m.BloodQuantity,
                DonateDate = m.DonateDate,
                Comment = m.Comment
            }).ToList();
            return View(model);
        }
    }
}