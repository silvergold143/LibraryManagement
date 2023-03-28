using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagement.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        [Required]
        [Display(Name ="Mobile Number")]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(length:10,ErrorMessage ="Mobile number must be 10 digits.")]
        public string MobileNo { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat( ApplyFormatInEditMode =true,DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime BirthDate { get; set; }
        [Required]
        [Display(Name = "Email Id")]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^.*(?=.{10,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&+=]).*$", ErrorMessage ="week Password")]
        
        public string Password { get; set; }
        
        [Display(Name = "Department")]
        public string DepartmentId { get; set; }

        [Display(Name = "Library")]
        public string LibraryId { get; set; }
        [Required(ErrorMessage ="Select at least one Hobby.")]
        public string Hobbies { get; set; }
        [Required]
        [Display(Name ="Select Photo")]
        public string Photo { get; set; }
    }
}