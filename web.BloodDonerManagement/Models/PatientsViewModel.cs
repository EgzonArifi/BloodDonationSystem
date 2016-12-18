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
        public string BloodType { get; set; }
        public DateTime BirthDate { get; set; }
    }
}