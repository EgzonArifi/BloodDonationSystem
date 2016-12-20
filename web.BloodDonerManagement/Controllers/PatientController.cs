using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.BloodDonerManagement.Models;

namespace web.BloodDonerManagement.Controllers
{
   [Authorize]
    public class PatientController : BaseController
    {
        public JsonResult datareport()
        {
            List<PatientsViewModel> model = db.Patient.Select(m => new PatientsViewModel
            {
                Id = m.Id,
                Name = m.Name,
                LastName = m.Lastname,
                BirthDate = m.BirthDate,
                BloodType = m.BloodType,
                Patient = m.Name + " " + m.Lastname,
                Address = m.Address,
                City = m.City,
                PhoneNumber = m.PhoneNumber,
                Email = m.Email,
                PatientGender = m.PatientGender
            }).ToList();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        // GET: Patient
        public ActionResult Index()
        {
            //var stock = db.BloodStock.Include("Patient").Include("Doctor");
            List<PatientsViewModel> model = db.Patient.Select(m => new PatientsViewModel
            {
                Id = m.Id,
                Name = m.Name,
                LastName = m.Lastname,
                BirthDate = m.BirthDate,
                BloodType = m.BloodType,
                Patient = m.Name + " " + m.Lastname,
                Address = m.Address,
                City = m.City,
                Email = m.Email,
                PhoneNumber = m.PhoneNumber,
                PatientGender = m.PatientGender
            }).ToList();
            ViewBag.bloodtype = Enum.GetValues(typeof(BloodType));//.Cast < string[]>() ;
            ViewBag.gender = Enum.GetValues(typeof(Gender));
            return View(model);
  
        }

        public ActionResult addOrUpdate(PatientsViewModel model)
        {
            if (model.Id == 0)
            {
                db.Patient.Add(new Patient
                {
                    BirthDate = model.BirthDate,
                    BloodType = model.BloodType,
                    Lastname = model.LastName,
                    Name = model.Name,
                    Address = model.Address,
                    City = model.City,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    PatientGender = model.PatientGender
                });
                db.SaveChanges();
                Session["alertAddNew"] = "True";
            }
            else
            {
                var patient = db.Patient.Where(x => x.Id == model.Id).FirstOrDefault();
                if (patient != null)
                {
                    patient.Name = model.Name;
                    patient.BloodType = model.BloodType;
                    patient.Lastname = model.LastName;
                    patient.BirthDate = model.BirthDate;
                    patient.Address = model.Address;
                    patient.Email = model.Email;
                    patient.PhoneNumber = model.PhoneNumber;
                    patient.City = model.City;
                    patient.PatientGender = model.PatientGender;
                    db.SaveChanges();
                    Session["alertEdit"] = "True";
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult delete(int Id)
        {
            var patient = db.Patient.Where(x => x.Id == Id).FirstOrDefault();
            if (patient != null)
            {
                db.Patient.Remove(patient);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}