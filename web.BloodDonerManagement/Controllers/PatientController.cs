using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.BloodDonerManagement.DAL;
using web.BloodDonerManagement.Models;

namespace web.BloodDonerManagement.Controllers
{
   [Authorize]
    public class PatientController : BaseController
    {
        private IRepository<Patient> _repository = null;
        public PatientController()
        {
            this._repository = new Repository<Patient>();
        }
        public JsonResult allPatients()
        {
            var employees = _repository.GetAll();
            return Json(employees.ToList(), JsonRequestBehavior.AllowGet);
        }

        // GET: Patient
        public ActionResult Index()
        {
            var employees = _repository.GetAll();
            ViewBag.bloodtype = Enum.GetValues(typeof(BloodType));
            ViewBag.gender = Enum.GetValues(typeof(Gender));
            return View(employees.ToList());
  
        }

        public ActionResult addOrUpdate(Patient model)
        {
            if (model.Id == 0)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        _repository.Insert(model);
                        _repository.Save();
                    }
                    Session["alertAddNew"] = "True";
                }
                catch (Exception ex)
                {
                    return View("Error", new HandleErrorInfo(ex, "Index", "Patient"));
                }

            }
            else
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        _repository.Update(model);
                        _repository.Save();
                    }
                }
                catch (Exception ex)
                {
                    return View("Error", new HandleErrorInfo(ex, "Index", "Patient"));
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
                var donation = db.BloodStock.Where(x => x.Patient.Id == Id);
                foreach (var item in donation)
                {
                 db.BloodStock.Remove(item);
                }
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}