using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcDemo.Models
{
    public class Student
    {
        public int ID { get; set; }
        
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage="Roll number is required!")]
        public int RollNo { get; set; }

        [Required(AllowEmptyStrings=false,ErrorMessage="Please enter first name!")]
        [Display(Name="First Name")]
        public string FName { get; set; }

        [Display(Name = "Last Name")]
        [Required(AllowEmptyStrings=false,ErrorMessage="Please enter last name!")]
        public string LName { get; set; }
    }
}