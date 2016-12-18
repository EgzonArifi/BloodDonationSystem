using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.BloodDonerManagement.Models
{
    public class PatientsViewModel
    {
        public int Id { get; set; }
        public string Patient { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public BloodType BloodType { get; set; }
        public DateTime BirthDate { get; set; }
    }
}