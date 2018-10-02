using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationTracker.Models
{
    public class LocationStudy
    {
        public int StudyID { get; set; }
        public int LocationID { get; set; }

        public Study Study { get; set; }
        public Location Location { get; set; }
    }
}
