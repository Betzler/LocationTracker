using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationTracker.Models.ViewModels
{
    public class StudyHistoryDeleteViewModel
    { 
        public int StudyID { get; set; }
        public int StudyHistoryID { get; set; }
        public string StudyName { get; set; }
        public int StatusID { get; set; }
        public int StudyTypeID { get; set; }
        public string StatusName { get; set; }
        public string StudyTypeName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
