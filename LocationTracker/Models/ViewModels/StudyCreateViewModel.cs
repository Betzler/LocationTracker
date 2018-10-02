using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationTracker.Models.ViewModels
{
    public partial class StudyCreateLocationViewModel
    {
        public int LocationID { get; set; }
        public string LocationCode { get; set; }
        public string DivisionName { get; set; }
    }

    public partial class StudyCreateViewModel
    {
        public string StudyName { get; set; }
        public int StudySize { get; set; }
        public int[] SelectedLocations { get; set; }
        public virtual IList<StudyCreateLocationViewModel> SelectedLocationsList { get; set; }
        public virtual IList<StudyCreateLocationViewModel> LocationList { get; set; }
    }
}
