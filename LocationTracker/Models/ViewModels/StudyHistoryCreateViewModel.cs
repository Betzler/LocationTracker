using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.DataAnnotations;

namespace LocationTracker.Models.ViewModels
{
    public class StudyHistoryCreateViewModel
    { 
        public int StudyHistoryID { get; set; }
        
        [Display(Name = "Study Name")]
        public int StudyID { get; set; }

        [Display(Name = "Status")]
        public int StatusID { get; set; }

        [Display(Name ="Status")]
        public string StatusName { get; set; }

        [Display(Name = "Study Type")]
        public int StudyTypeID { get; set; }

        [Display(Name = "Study Type")]
        public string StudyTypeName { get; set; }

        [Display(Name = "Performed By")]
        public int VendorID { get; set; }

        [Display(Name = "Date Started")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Date Completed")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Underrated Issues")]
        public int? UnderratedIssues { get; set; }

        [Display(Name = "Arc Flash Issues")]
        public int? ArcFlashIssues { get; set; }

        [Display(Name = "Equipment Protection Issues")]
        public int? EquipmentProtectionIssues { get; set; }

        [Display(Name = "Comments")]
        public string Comment { get; set; }
    }
}
