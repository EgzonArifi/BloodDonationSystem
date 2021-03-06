﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web.BloodDonerManagement.Models;

namespace web.BloodDonerManagement.DAL
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<Patient> GetAll();
        T GetById(object Id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(Object Id);
        void Save();
    }
}
