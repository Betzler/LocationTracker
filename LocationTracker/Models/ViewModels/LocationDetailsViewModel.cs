using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.DataAnnotations;

namespace LocationTracker.Models.ViewModels
{
    public class LocationDetailsViewModel
    {
        public int LocationID { get; set; }

        [Display(Name = "Location Code")]
        public string LocationCode { get; set; }

        [Display(Name ="Division")]
        public string DivisionName { get; set; }

        [Display(Name = "Business Unit")]
        public string BusinessUnitName { get; set; }

        [Display(Name = "Street Address 1")]
        public string FirstAddress { get; set; }

        [Display(Name = "Street Address 2")]
        public string SecondAddress { get; set; }

        public string City { get; set; }

        [Display(Name = "State/Province")]
        public string StateProvince { get; set; }

        public string Country { get; set; }

        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        public float? Lattitude { get; set; }
        public float? Longitude { get; set; }

    }
}
