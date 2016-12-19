using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.BloodDonerManagement.Models;

namespace web.BloodDonerManagement.Controllers
{
    public class DoctorsController : BaseController
    {
        // GET: Doctors
        public ActionResult Index()
        {
            List<DoctorsViewModel> model = db.Doctors.Select(m => new DoctorsViewModel
            {
                Id = m.Id,
                FirstName = m.FirstName,
                LastName = m.LastName,
                BirthDate = m.BirthDate,
                Doctor = m.FirstName + " " + m.LastName,
                Address = m.Address,
                City = m.City,
                Email = m.Email,
                PhoneNumber = m.PhoneNumber,
                DoctorGender = m.DoctorGender
            }).ToList();
            ViewBag.gender = Enum.GetValues(typeof(Gender));
            return View(model);
        }

        public ActionResult addOrUpdate(DoctorsViewModel model)
        {
            if (model.Id == 0)
            {
                db.Doctors.Add(new Doctors
                {
                    BirthDate = model.BirthDate,
                    LastName = model.LastName,
                    FirstName = model.FirstName,
                    Address = model.Address,
                    City = model.City,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    DoctorGender = model.DoctorGender
                });
                db.SaveChanges();
            }
            else
            {
                var doctor = db.Doctors.Where(x => x.Id == model.Id).FirstOrDefault();
                if (doctor != null)
                {
                    doctor.FirstName = model.FirstName;
                    doctor.LastName = model.LastName;
                    doctor.BirthDate = model.BirthDate;
                    doctor.Address = model.Address;
                    doctor.Email = model.Email;
                    doctor.PhoneNumber = model.PhoneNumber;
                    doctor.City = model.City;
                    doctor.DoctorGender = model.DoctorGender;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
        public ActionResult delete(int Id)
        {
            var doctor = db.Doctors.Where(x => x.Id == Id).FirstOrDefault();
            if (doctor != null)
            {
                db.Doctors.Remove(doctor);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}