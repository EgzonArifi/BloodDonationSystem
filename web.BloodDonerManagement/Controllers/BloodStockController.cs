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
                Comment = m.FirstOrDefault().Comment,
                PatientId = m.FirstOrDefault().Patient.Id,
                DoctorId = m.FirstOrDefault().Doctor.Id
            }).ToList();
            return View(model);
        }
        public ActionResult Create()
        {
            return View("Create");
        }
        public ActionResult Edit(int Id, int PatientId, int DoctorId)
        {
            List<BloodStockViewModel> model = db.BloodStock
                .Where(x => x.Id == Id)
                .GroupBy(l => l.Patient.BloodType)
                .Select(m => new BloodStockViewModel
                {
                    Id = m.FirstOrDefault().Id,
                    Patient = m.FirstOrDefault().Patient.Name + " " + m.FirstOrDefault().Patient.Lastname,
                    DoctorName = m.FirstOrDefault().Doctor.FirstName + " " + m.FirstOrDefault().Doctor.LastName,
                    BloodType = m.FirstOrDefault().Patient.BloodType.ToString(),
                    BloodQuantity = m.Sum(c => c.BloodQuantity),
                    DonateDate = m.FirstOrDefault().DonateDate,
                    Comment = m.FirstOrDefault().Comment,
                    PatientId = PatientId,
                    DoctorId = DoctorId
                }).ToList();
            return View(model);
        }
        public ActionResult addOrUpdate(BloodStockViewModel model)
        {
            var patient = db.Patient.Where(x => x.Id == model.PatientId).FirstOrDefault();
            var doctor = db.Doctors.Where(x => x.Id == model.DoctorId).FirstOrDefault();
            if (model.Id == 0)
                {
                    db.BloodStock.Add(new BloodStock
                    {
                        Patient = patient,
                        Doctor = doctor,
                        DonateDate = DateTime.Now,
                        Comment = model.Comment,
                        BloodQuantity = model.BloodQuantity,

                    });
                    db.SaveChanges();
                    //Session["alertAddNew"] = "True";
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
                        
                        db.SaveChanges();
                       // Session["alertEdit"] = "True";
                    }
                }
                return RedirectToAction("Index");
                //return View("Create");
        }
        public ActionResult delete(int Id)
        {
            var blood = db.BloodStock.Where(x => x.Id == Id);
            if (blood != null)
            {
                foreach (var item in blood)
                {
                 db.BloodStock.Remove(item);
                }
                db.SaveChanges();
            }

            return RedirectToAction("Index");
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
        [HttpPost]
        public JsonResult DoctorSearch(string prefix)
        {
            //Note : you can bind same list from database  
            if (prefix == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            List<DoctorsViewModel> model = db.Doctors.Select(m => new DoctorsViewModel
            {
                Id = m.Id,
                FirstName = m.FirstName + " " + m.LastName,
            }).Where(c => c.FirstName.StartsWith(prefix)).ToList();
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}