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
    [FluentValidation.Attributes.Validator(typeof(AddressValidator))]
    public class Address
    {
        public int AddressID { get; set; }
        public string FirstAddress { get; set; }
        public string SecondAddress { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }

        public float? Lattitude { get; set; }
        public float? Longitude { get; set; }

        public virtual Location Location { get; set; }
    }
}
