using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using web.BloodDonerManagement.Models;

namespace web.BloodDonerManagement.DAL
{
    public class DoctorRepository : IDoctor,IDisposable
    {
        private ApplicationDbContext context;

        public DoctorRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<DoctorsViewModel> GetDoctors()
        {
            return context.Doctors.Select(m => new DoctorsViewModel
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
            }).OrderByDescending(o => o.Id).ToList();
        }

        public DoctorsViewModel GetDoctorByID(int Id)
        {
            return context.Doctors.Where(x => x.Id == Id).Select(m => new DoctorsViewModel
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
            }).ToList().FirstOrDefault(); 
        }

        public void InsertDoctor(DoctorsViewModel model)
        {
            context.Doctors.Add(new Doctors
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
        }

        public void DeleteDoctor(int Id)
        {
            var doctor = context.Doctors.Where(x => x.Id == Id).FirstOrDefault();
            if (doctor != null)
            {
                context.Doctors.Remove(doctor);
                var donation = context.BloodStock.Where(x => x.Doctor.Id == Id);
                foreach (var item in donation)
                {
                    context.BloodStock.Remove(item);
                }
            }
        }

        public void UpdateDoctor(Doctors doctor)
        {
            context.Entry(doctor).State = EntityState.Modified;
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