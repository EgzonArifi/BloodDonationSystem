using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web.BloodDonerManagement.Models;

namespace web.BloodDonerManagement.DAL
{
    interface IBloodStock : IDisposable
    {
        IEnumerable<BloodStockViewModel> GetBloodStock();
        IEnumerable<BloodStockViewModel> GetBloodStock(int Id, int PatientId, int DoctorId);
        BloodStockViewModel GetDoctorByID(int stockId);
        void InsertBloodDonation(BloodStockViewModel model);
        void DeleteBloodDonation(int stockId);
        void UpdateBloodDonation(BloodStock stock);

        IEnumerable<PatientsViewModel> PatientSearch(string prefix);
        IEnumerable<DoctorsViewModel> DoctorSearch(string prefix);

        void Save();
    }
}