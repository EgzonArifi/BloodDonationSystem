using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web.BloodDonerManagement.Models;

namespace web.BloodDonerManagement.DAL
{
    interface IDoctor : IDisposable
    {
        IEnumerable<DoctorsViewModel> GetDoctors();
        DoctorsViewModel GetDoctorByID(int doctorId);
        void InsertDoctor(DoctorsViewModel model);
        void DeleteDoctor(int doctorID);
        void UpdateDoctor(Doctors doctor);
        void Save();
    }
}
