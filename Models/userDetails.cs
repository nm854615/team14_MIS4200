﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace team14_MIS4200.Models
{
    public class userDetails
    {
        [Required]
        public Guid ID { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string firstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }
        [Display(Name ="Birthday")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Required")]
        public string birthday { get; set; }

        [Display(Name = "Operating Group")]
        [Required(ErrorMessage = "Required")]
        public OperatingGroup group { get; set; }

        public enum OperatingGroup
        {
            Boston = 1,
            Charlotte = 2,
            Chicago = 3,
            Cincinnati = 4,
            Cleveland = 5,
            Columbus = 6,
            CustomerExperienceAndDesign = 7,
            DataAndAnalytics = 8,
            Digital = 9,
            EnergyAndUtilities = 10,
            EnterpriseApplicationsAndSolutions = 11,
            EnterpriseCollaboration = 12,
            FinancialServices = 13,
            Healthcare = 14,
            India = 15,
            Indianapolis = 16,
            Insurance = 17,
            Louisville = 18,
            MarketingOperationsAndCRM = 19,
            Miami = 20,
            MicrosoftPartnership = 21,
            MobileAppDevelopment = 22,
            ModernSoftwareDelivery = 23,
            OperationalAndProcessExcellence = 24,
            PeopleAndChange = 25,
            Seattle = 26,
            StLouis = 27,
            TalentManagement = 28,
            Tampa = 29,
            TechnologySolutionServices = 30

        }
        [Display(Name = "Employee Title")]
        [Required(ErrorMessage = "Required")]
        public EmployeeTitle title { get; set; }

        public enum EmployeeTitle
        {
            Consultant = 1,
            SeniorConsultant = 2,
            Manager = 3,
            Architect = 4,
            SeniorManager = 5,
            SeniorArchitect = 6,
            PrincipalArchitect = 7,
            Partner = 8

        }
        [Display(Name = "Hire Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Required")]
        public DateTime hireDateTime { get; set; }
    }
}