using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocationTracker.Models
{
    public class BusinessUnit
    {
        public int BusinessUnitID { get; set; }
        public int DivisionID { get; set; }
        public string BusinessUnitName { get; set; }

        public virtual ICollection<Location> Locations { get; set; }
        public virtual Division Division { get; set; }
    }
}
