using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using LocationTracker.Models.Validators;

namespace LocationTracker.Models
{
    public class Location
    {
        public int LocationID { get; set; }
        public string LocationCode { get; set; }
        public int? DivisionID { get; set; }
        public int? BusinessUnitID { get; set; }
        public int AddressID { get; set; }
        
        public virtual Division Division { get; set; }
        public virtual BusinessUnit BusinessUnit { get; set; }
        public virtual Address Address { get; set; }
        public virtual IList<LocationStudy> LocationStudies { get; set; }
        public virtual IList<Assessment> Assessments { get; set; }
    }
}

