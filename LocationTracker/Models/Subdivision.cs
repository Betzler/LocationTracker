using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationTracker.Models
{
    public class Subdivision
    {
        public int SubdivisionID { get; set; }
        public int CountryID { get; set; }
        public string AlphaTwo { get; set; }
        public string SubdivisionName { get; set; }

        public virtual Country Country { get; set; }
    }
}
