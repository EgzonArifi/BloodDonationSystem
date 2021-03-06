﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using web.BloodDonerManagement.Models;

namespace web.BloodDonerManagement.DAL
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private ApplicationDbContext db;
        private DbSet<T> dbSet;

        public Repository()
        {
            db = new ApplicationDbContext();
            dbSet = db.Set<T>();
        }
        public IEnumerable<Patient> GetAll()
        {
            return db.Patient.OrderByDescending(o => o.Id).ToList();
        }

        public T GetById(object Id)
        {
            return dbSet.Find(Id);
        }

        public void Insert(T obj)
        {
            dbSet.Add(obj);
        }
        public void Update(T obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object Id)
        {
            T getObjById = dbSet.Find(Id);
            dbSet.Remove(getObjById);
        }
        public void Save()
        {
            db.SaveChanges();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.db != null)
                {
                    this.db.Dispose();
                    this.db = null;
                }
            }
        }
    }
}