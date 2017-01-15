using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web.BloodDonerManagement.Models;

namespace web.BloodDonerManagement.DAL
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        private ApplicationDbContext context;

        public PatientRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Patient> GetOrderedPatients()
        {
            return context.Patient.OrderByDescending(o => o.Id).ToList();
        }
    }
}