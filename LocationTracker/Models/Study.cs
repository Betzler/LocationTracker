using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationTracker.Models
{
    public class Study
    {
        public int StudyID { get; set; }
        public string StudyName { get; set; }
        public int? StudySize { get; set; }

        public virtual IList<LocationStudy> LocationStudies { get; set; }
        public virtual IList<StudyHistory> StudyHistory { get; set; }
    }
}
