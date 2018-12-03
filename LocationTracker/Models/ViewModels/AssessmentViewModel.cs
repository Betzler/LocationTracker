using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using LocationTracker.Models.ViewModels;
using FluentValidation;
using LocationTracker.Models.Validators;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocationTracker.Models.ViewModels
{
    public partial class LocationsViewModel 
    {
        public int LocationID { get; set; }
        public string LocationCode { get; set; }
    }

    public partial class StatusesViewModel 
    {
        public int StatusID { get; set; }
        public string StatusName { get; set; }
    }

    public class AssessmentViewModel
    {
        public int AssessmentID { get; set; }
        public int LocationID { get; set; }

        [Display(Name = "Performed By")]
        public int VendorID { get; set; }

        public IList<SelectListItem> VendorList { get; set; }

        public int StatusID { get; set; }

        [Display(Name = "Study Required")]
        public bool? StudyRequired { get; set; }

        public IList<SelectListItem> TrueFalseNullSL { get; set; }

        [Display(Name = "Start Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM-dd-yyyy}")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM-dd-yyyy}")]
        public DateTime? EndDate { get; set; }

        public string Comment { get; set; }

        [Display(Name = "Location Code")]
        public IList<SelectListItem> LocationsList { get; set; }

        [Display(Name = "Status")]
        public IList<SelectListItem> StatusesList { get; set; }

    }
}
