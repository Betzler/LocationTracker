using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace LocationTracker.Models.ViewModels
{
    public partial class StudyIndexLocationViewModel
    {
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public string DivisionName { get; set; }
        public string LocationFullName { get; set; }
    }

    public partial class StudyIndexViewModel
    {
        public int StudyID { get; set; }

        [Display(Name = "Study Name")]
        public string StudyName { get; set; }

        [Display(Name = "Last Study Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? LastStudyDate { get; set; }

        [Display(Name = "Expire Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? ExpireDate { get; set; }
        
        [Display(Name = "Locations")]
        public IList<StudyIndexLocationViewModel> LocationVM { get; set; }
    }

}

