using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.BloodDonerManagement.Models;

namespace web.BloodDonerManagement.Controllers
{
   [Authorize]
    public class PatientController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        // GET: Patient
        public ActionResult Index()
        {
            List<PatientsViewModel> model = context.Patient.Select(m => new PatientsViewModel
            {
                BirthDate = m.BirthDate,
                BloodType = m.BloodType.ToString(),
                Patient = m.Name + " " + m.Lastname
            }).ToList();
            return View(model);
        }
    }
}