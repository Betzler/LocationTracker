using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationTracker.Models
{
    public class StudyHistory
    {
        public int StudyHistoryID { get; set; }
        public int StudyID { get; set; }
        public int StatusID { get; set; }
        public int StudyTypeID { get; set; }
        public int VendorID { get; set; }
        public int? UnderratedIssues { get; set; }
        public int? ArcFlashIssues { get; set; }
        public int? EquipmentProtectionIssues { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string Comment { get; set; }

        public virtual Study Study { get; set; }
        public virtual StudyType StudyType { get; set; }
        public virtual Status Status { get; set; }
        public virtual Vendor Vendor { get; set; }

    }
}
