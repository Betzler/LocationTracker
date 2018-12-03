using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocationTracker.Models.ViewModels
{
    public partial class StudyCreateViewModel : LocationCodeViewModel
    {
        [Display(Name = "Study Name")]
        public string StudyName { get; set; }

        [Display(Name = "Study Size")]
        public int StudySize { get; set; }

        [Display(Name = "Locations")]
        public List<int> SelectedLocations { get; set; }

        public IList<LocationCodeViewModel> LocationsList { get; set; }
    }
}
