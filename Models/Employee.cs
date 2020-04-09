using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace team14_MIS4200.Models
{
    public class Employee
    {
        public int employeeId { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is Required")]
        public string employeeFirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is Required")]
        public string employeeLastName { get; set; }

        [Display(Name = "Birthday")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Required")]
        public string birthday { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Required")]
        public string email { get; set; }

        [Display(Name = "Hire Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Required")]
        public DateTime hireDateTime { get; set; }

        [Display(Name = "Employee Title")]
        [Required(ErrorMessage = "Required")]
        public string employeeTitle { get; set; }

        [Display(Name = "Operating Group")]
        [Required(ErrorMessage = "Required")]
        public string operatingGroup { get; set; }


    }
}