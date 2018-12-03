using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.DataAnnotations;

namespace LocationTracker.Models.ViewModels
{
    public class StudyResultViewModel
    {
        public int StudyResultID { get; set; }

        public int StudyID { get; set; }

        [Display(Name="Underrated")]
        public int UnderratedIssues { get; set; }

        [Display(Name = "Arc Flash")]
        public int ArcFlashIssues { get; set; }

        [Display(Name = "Equipment Protection")]
        public int EquipmentProtectionIssues { get; set; }

        [Display(Name = "Date Completed")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DateCompleted { get; set; }

    }
}
