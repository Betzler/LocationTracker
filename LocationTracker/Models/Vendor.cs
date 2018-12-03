using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationTracker.Models
{
    public class Vendor
    {
        public int VendorID { get; set; }
        public int VendorNumber { get; set; }
        public string VendorName { get; set; }

        public virtual IList<Assessment> Assessments { get; set; }
        public virtual IList<StudyHistory> StudyHistories { get; set; }
    }
}
