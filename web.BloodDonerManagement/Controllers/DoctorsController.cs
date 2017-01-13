using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.BloodDonerManagement.DAL;
using web.BloodDonerManagement.Models;

namespace web.BloodDonerManagement.Controllers
{
    public class DoctorsController : BaseController
    {
        private IDoctor doctorRepository;

        public DoctorsController()
        {
            this.doctorRepository = new DoctorRepository(new ApplicationDbContext());
        }
        // GET: Doctors
        public ActionResult Index()
        {
            var model = doctorRepository.GetDoctors();
            ViewBag.gender = Enum.GetValues(typeof(Gender));
            return View(model);
        }

        public ActionResult addOrUpdate(DoctorsViewModel model)
        {
            if (model.Id == 0)
            {
                doctorRepository.InsertDoctor(model);
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
                    doctorRepository.UpdateDoctor(doctor);
                }
            }
            doctorRepository.Save();
            return RedirectToAction("Index");
        }
        public ActionResult delete(int Id)
        {
            doctorRepository.DeleteDoctor(Id);
            doctorRepository.Save();
            return RedirectToAction("Index");
        }
    }
}