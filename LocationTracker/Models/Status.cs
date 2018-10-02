using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationTracker.Models
{
    public class Status
    {
        public int StatusID { get; set; }
        public string StatusName { get; set; }

        public virtual IList<StudyHistory> StudyHistories { get; set; }
    }
}
