using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationTracker.Models
{
    public class StudyType
    {
        public int StudyTypeID { get; set; }
        public string StudyTypeName { get; set; }

        public virtual IList<StudyHistory> StudyHistories { get; set; }
    }
}
