﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.BloodDonerManagement.Models
{
    public class DoctorsViewModel
    {
        public int Id { get; set; }
        public string Doctor { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Gender DoctorGender { get; set; }
    }
}