using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace team14_MIS4200.Models
{
    public class Recognition
    {
        
        [Key] // the data annotation is necessary because there is a field called, ID,
              // in the table and it is not the PK for the record
        public int RecognitionID { get; set; }
        //ID of person being recognized
        public Guid ID { get; set; }
        [ForeignKey(name: "ID")]
        public virtual userDetails userDetails { get; set; }
        [Required]
        [Display(Name = "Date of Recognition")]
        public DateTime DateOfRecognition { get; set; }
        //…
        public string employeeFirstName { get; set; }
        [Display(Name = "Employee Last Name")]
        [Required(ErrorMessage = "Last Name is Required")]
        public string employeeLastName { get; set; }
        [Display(Name = "Recognition Details")]
        [Required(ErrorMessage = "Explanation of recognition is Required")]
        public string recognitionDetails { get; set; }
        [Required]
        [Display(Name = "Core Value")]
        public CoreValue award { get; set; }
        public enum CoreValue
        {
            Excellence = 1,
            Culture = 2,
            Integrity = 3,
            Stewardship = 4,
            Innovate = 5,
            Passion = 6,
            Balance = 7
        }

    }
}