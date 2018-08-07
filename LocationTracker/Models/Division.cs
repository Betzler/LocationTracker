using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocationTracker.Models
{
    public class Division
    {
        public int DivisionID { get; set; }
        public string DivisionName { get; set; }

        public virtual ICollection<Location> Locations { get; set; }
    }
}
