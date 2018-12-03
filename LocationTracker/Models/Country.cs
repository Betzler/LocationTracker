using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationTracker.Models
{
    public class Country
    {
        public int CountryID { get; set;}
        public string AlphaTwo { get; set; }
        public string AlphaThree { get; set; }
        public string CountryName { get; set; }

        public virtual IList<Subdivision> Subdivisions { get; set; }
    }
}
