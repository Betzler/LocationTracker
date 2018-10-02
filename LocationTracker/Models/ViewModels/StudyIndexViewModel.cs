using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationTracker.Models.ViewModels
{
    public partial class StudyIndexLocationViewModel
    {
        public string LocationName { get; set; }
        public string DivisionName { get; set; }
    }

    public partial class StudyIndexViewModel
    {
        public int StudyID { get; set; }
        public string StudyName { get; set; }

        public virtual IList<StudyIndexLocationViewModel> LocationVM { get; set; }

    }
}
