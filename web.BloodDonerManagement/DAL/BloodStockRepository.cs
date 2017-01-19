using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using web.BloodDonerManagement.Models;

namespace web.BloodDonerManagement.DAL
{
    public class BloodStockRepository : IBloodStock, IDisposable
    {
        private ApplicationDbContext context;

        public BloodStockRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<BloodStockViewModel> GetBloodStock()
        {
            return context.BloodStock.Select(m => new BloodStockViewModel
                {
                    Id = m.Id,
                    Patient = m.Patient.Name + " " + m.Patient.Lastname,
                    BloodType = m.Patient.BloodType.ToString(),
                    BloodQuantity = m.BloodQuantity,
                    DonateDate = m.DonateDate,
                    Comment = m.Comment,
                    PatientId = m.Patient.Id,
                    DoctorId = m.Doctor.Id
                }).OrderByDescending(o => o.Id).ToList();
        }
        public IEnumerable<BloodStockViewModel> GetBloodStock(int Id, int PatientId, int DoctorId)
        {
            return context.BloodStock
                .Where(x => x.Id == Id)
                .GroupBy(l => l.Patient.BloodType)
                .Select(m => new BloodStockViewModel
                {
                    Id = m.FirstOrDefault().Id,
                    Patient = m.FirstOrDefault().Patient.Name + " " + m.FirstOrDefault().Patient.Lastname,
                    DoctorName = m.FirstOrDefault().Doctor.FirstName + " " + m.FirstOrDefault().Doctor.LastName,
                    BloodType = m.FirstOrDefault().Patient.BloodType.ToString(),
                    BloodQuantity = m.Sum(c => c.BloodQuantity),
                    DonateDate = m.FirstOrDefault().DonateDate,
                    Comment = m.FirstOrDefault().Comment,
                    PatientId = PatientId,
                    DoctorId = DoctorId
                }).ToList();
        }
        public BloodStockViewModel GetDoctorByID(int stockId)
        {
            return context.BloodStock.Where(x => x.Id == stockId).Select(m => new BloodStockViewModel
            {
                Id = m.Id,
                Patient = m.Patient.Name + " " + m.Patient.Lastname,
            }).ToList().FirstOrDefault();
        }

        public void InsertBloodDonation(BloodStockViewModel model)
        {
            var patient = context.Patient.Where(x => x.Id == model.PatientId).FirstOrDefault();
            var doctor = context.Doctors.Where(x => x.Id == model.DoctorId).FirstOrDefault();
            context.BloodStock.Add(new BloodStock
            {
                Patient = patient,
                Doctor = doctor,
                DonateDate = DateTime.Now,
                Comment = model.Comment,
                BloodQuantity = model.BloodQuantity
            });
        }

        public void DeleteBloodDonation(int stockId)
        {
            var blood = context.BloodStock.Include("Patient").Where(x => x.Patient.Id == stockId);
            if (blood != null)
            {
                context.BloodStock.RemoveRange(blood);

                context.SaveChanges();
            }
        }

        public void UpdateBloodDonation(BloodStock stock)
        {
            context.Entry(stock).State = EntityState.Modified;
        }


        public IEnumerable<PatientsViewModel> PatientSearch(string prefix)
        {
            return context.Patient.Select(m => new PatientsViewModel
            {
                Id = m.Id,
                Name = m.Name + " " + m.Lastname,
            }).Where(c => c.Name.StartsWith(prefix)).ToList();
        }
        public IEnumerable<DoctorsViewModel> DoctorSearch(string prefix)
        {
            return context.Doctors.Select(m => new DoctorsViewModel
            {
                Id = m.Id,
                FirstName = m.FirstName + " " + m.LastName,
            }).Where(c => c.FirstName.StartsWith(prefix)).ToList();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}