using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.BloodDonerManagement.Models
{
    public class BloodDoner
    {
        public int Id { get; set; }
        public string BloodType { get; set; }
        public DateTime DonnationDate { get; set; }
    }
}