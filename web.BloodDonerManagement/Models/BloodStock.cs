using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.BloodDonerManagement.Models
{
    public class BloodStock
    {
        public int Id { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime DonateDate { get; set; }
        public decimal BloodQuantity { get; set; }
        public string Comment { get; set; }
    }
}