using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace team14_MIS4200.Models
{
    public class Recognition
    {
        public int recognitionID { get; set; }
        [Display(Name = "Employee First Name")]
        [Required(ErrorMessage = "First Name is Required")]
        public string employeeFirstName { get; set; }
        [Display(Name = "Employee Last Name")]
        [Required(ErrorMessage = "Last Name is Required")]
        public string employeeLastName { get; set; }
        [Display(Name = "Recognition Details")]
        [Required(ErrorMessage = "Explanation of recognition is Required")]
        public string recognitionDetails { get; set; }
        [Display(Name = "Core Value")]
        [Required(ErrorMessage = "Core Value is Required")]
        public string coreValue { get; set; }

    }
}