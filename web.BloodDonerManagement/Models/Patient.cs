using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace web.BloodDonerManagement.Models
{
    public class Patient
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "You must enter firstname")]
        public string Name { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public BloodType BloodType { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public Gender PatientGender { get; set; }
    }
}