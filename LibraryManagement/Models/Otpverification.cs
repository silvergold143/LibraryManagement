using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagement.Models
{
    public class Otpverification
    {
        [Required]
        [Display(Name ="Enter Otp")]
        public int OTP { get; set; }
    }
}