using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationTracker.Models.ViewModels
{
    public class StudyHistoryDeleteViewModel
    { 
        public int StudyHistoryID { get; set; }
        public string StudyName { get; set; }
        public int StatusID { get; set; }
        public int StudyTypeID { get; set; }
        public string StatusName { get; set; }
        public string StudyTypeName { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}
