﻿using System;
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
        public JsonResult PatientSearch(string prefix)
       {
            //Note : you can bind same list from database  
            if (prefix == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
           List<PatientsViewModel> model = db.Patient.Select(m => new PatientsViewModel
            {
                Id = m.Id,
                Name = m.Name + " " + m.Lastname ,
            }).Where(c => c.Name.StartsWith(prefix)).ToList();
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}