using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web.BloodDonerManagement.Models;

namespace web.BloodDonerManagement.DAL
{
    interface IPatientRepository : IRepository<Patient>
    {
        IEnumerable<Patient> GetOrderedPatients();
    }
}
