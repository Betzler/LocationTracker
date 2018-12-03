using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using LocationTracker.Models.ViewModels;

namespace LocationTracker.Models.ViewModels
{
    public class AssessmentIndexViewModel
    {
        public int AssessmentID { get; set; }
        public int LocationID { get; set; }

        [Display(Name = "Location Code")]
        public string LocationCode { get; set; }

        [Display(Name = "Performed By")]
        public string PerformedBy { get; set; }

        [Display(Name = "Status")]
        public string StatusName { get; set; }

        [UIHint("TrueFalseNull")]
        [Display(Name = "Study Required")]
        public bool? StudyRequired { get; set; }

        [Display(Name = "Start Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? EndDate { get; set; }

        public string Comment { get; set; }

    }
}
