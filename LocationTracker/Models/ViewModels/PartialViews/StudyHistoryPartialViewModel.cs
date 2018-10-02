using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationTracker.Models.ViewModels.PartialViews
{
    public class StudyHistoryPartialViewModel
    {
        public int StudyHistoryID { get; set; }
        public int StudyID { get; set; }
        public int StatusID { get; set; }
        public string StatusName { get; set; }
        public int StudyTypeID { get; set; }
        public string StudyTypeName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Comment { get; set; }
    }
}
