using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web.BloodDonerManagement.Models;

namespace web.BloodDonerManagement.DAL
{
    public class UnitOfWork : IDisposable
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        private GenericRepository<Patient> patientRepository;

        public GenericRepository<Patient> PatientRepository
        {
            get
            {

                if (this.patientRepository == null)
                {
                    this.patientRepository = new GenericRepository<Patient>(context);
                }
                return patientRepository;
            }
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