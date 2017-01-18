using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.BloodDonerManagement.DAL;
using web.BloodDonerManagement.Models;

namespace web.BloodDonerManagement.Controllers
{
    public class BloodStockController : BaseController
    {
        private IBloodStock bloodRepository;

        public BloodStockController()
        {
            this.bloodRepository = new BloodStockRepository(new ApplicationDbContext());
        }
        // GET: BloodStock
        [Authorize]
        public ActionResult Index()
        {
            var model = bloodRepository.GetBloodStock();
            return View(model);
        }
        public ActionResult Create()
        {
            return View("Create");
        }
        public ActionResult Edit(int Id, int PatientId, int DoctorId)
        {
            var model = bloodRepository.GetBloodStock(Id, PatientId, DoctorId);
            return View(model);
        }
        public ActionResult addOrUpdate(BloodStockViewModel model)
        {
            var patient = db.Patient.Where(x => x.Id == model.PatientId).FirstOrDefault();
            var doctor = db.Doctors.Where(x => x.Id == model.DoctorId).FirstOrDefault();
            if (model.Id == 0)
            {
                bloodRepository.InsertBloodDonation(model);
            }
            else
            {
                var blood = db.BloodStock.Where(x => x.Id == model.Id).FirstOrDefault();
                if (blood != null)
                {
                    blood.Patient = patient;
                    blood.Doctor = doctor;
                    blood.DonateDate = DateTime.Now;
                    blood.Comment = model.Comment;
                    blood.BloodQuantity = model.BloodQuantity;
                    
                    bloodRepository.UpdateBloodDonation(blood);
                }
            }
                bloodRepository.Save();
                return RedirectToAction("Index");
        }
        public ActionResult delete(int Id)
        {
            try
            {
                bloodRepository.DeleteBloodDonation(Id);
                bloodRepository.Save();
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Index", "BloodStock"));
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult PatientSearch(string prefix)
       {
            if (prefix == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            return Json(bloodRepository.PatientSearch(prefix), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DoctorSearch(string prefix)
        {
            if (prefix == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            return Json(bloodRepository.DoctorSearch(prefix), JsonRequestBehavior.AllowGet);
        }
    }
}