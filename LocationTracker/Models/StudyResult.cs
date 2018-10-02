using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationTracker.Models
{
    public class StudyResult
    {
        public int StudyResultID { get; set; }
        public int StudyHistoryID { get; set; }
        public int UnderratedIssues { get; set; }
        public int ArcFlashIssues { get; set; }
        public int EquipmentProtectionIssues { get; set; }

        public virtual StudyHistory StudyHistory { get; set; }
    }
}
