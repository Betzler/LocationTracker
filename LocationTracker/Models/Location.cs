using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocationTracker.Models
{
    public class Location
    {
        public int LocationID { get; set; }
        public string LocationCode { get; set; }
        public int? DivisionID { get; set; }
        public int? AddressID { get; set; }
         
        public virtual Division Division { get; set; }
        public virtual Address Address { get; set; }
    }
}

