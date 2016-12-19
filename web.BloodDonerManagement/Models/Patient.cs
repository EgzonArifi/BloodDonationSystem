﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.BloodDonerManagement.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime BirthDate { get; set; }
        public BloodType BloodType { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Gender PatientGender { get; set; }
    }
}