using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.BloodDonerManagement.Models
{
    public enum BloodType
    {
        Zero_Negative =1,
        Zero_Positive,
        A_Positive,
        A_Negative,
        B_Positive,
        B_Negative,
        AB_Positive,
        AB_Negative
    }

    public enum Gender
    {
        Male,
        Female,
    }
}