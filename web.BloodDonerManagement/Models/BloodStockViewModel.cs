using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.BloodDonerManagement.Models
{
    public class BloodStockViewModel
    {
        public int Id { get; set; }
        public string Patient { get; set; }
        public Doctors Doctor { get; set; }
        public DateTime DonateDate { get; set; }
        public decimal BloodQuantity { get; set; }
        public string Comment { get; set; }
        public string BloodType { get; set; }
    }

    public class BloodStockReportViewModel
    {
        public decimal BloodQuantity { get; set; }
        public string BloodType { get; set; }
    }
}