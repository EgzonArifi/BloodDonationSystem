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
                Patient = m.Name + " " + m.Lastname
            }).ToList();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        // GET: Patient
        public ActionResult Index()
        {
            var stock = db.BloodStock.Include("Patient").Include("Doctor");
            List<PatientsViewModel> model = db.Patient.Select(m => new PatientsViewModel
            {
                Id = m.Id,
                Name = m.Name,
                LastName = m.Lastname,
                BirthDate = m.BirthDate,
                BloodType = m.BloodType,
                Patient = m.Name + " " + m.Lastname
            }).ToList();
            ViewBag.bloodtype = Enum.GetValues(typeof(BloodType));//.Cast < string[]>() ;
            return View(model);
        }

        public ActionResult addupdate(PatientsViewModel model)
        {
            if (model.Id == 0)
            {
                db.Patient.Add(new Patient
                {
                    BirthDate = model.BirthDate,
                    BloodType = model.BloodType,
                    Lastname = model.LastName,
                    Name = model.Name
                });
                db.SaveChanges();
            }
            else
            {
                var patient = db.Patient.Where(x => x.Id == model.Id).FirstOrDefault();
                if (patient != null)
                {
                    patient.Name = model.Name;
                    //fill other columns form model
                    db.SaveChanges();
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