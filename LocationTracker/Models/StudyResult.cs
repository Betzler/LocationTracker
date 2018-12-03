using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationTracker.Models
{
    public class StudyResult
    {
        public int StudyResultID { get; set; }
        public int StudyID { get; set; }
        public int StudyTypeID { get; set; }
        public int StatusID { get; set; }
        public int UnderratedIssues { get; set; }
        public int ArcFlashIssues { get; set; }
        public int EquipmentProtectionIssues { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? DateCompleted { get; set; }


        public virtual Study Study { get; set; }
    }
}
