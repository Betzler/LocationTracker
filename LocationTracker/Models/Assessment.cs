using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationTracker.Models
{
    public class Assessment
    {
        public int AssessmentID { get; set; }
        public int LocationID { get; set; }
        public int VendorID { get; set; }
        public int StatusID { get; set; }
        public bool? StudyRequired { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Comment { get; set; }

        public virtual Location Location {get; set;}
        public virtual Status Status { get; set; }
        public virtual Vendor Vendor { get; set; }

    }
}
