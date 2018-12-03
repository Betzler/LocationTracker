using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using LocationTracker.Models;

namespace LocationTracker.Models.ViewModels
{
    public class LocationCreateViewModel
    {
        [Display(Name = "Location Code")]
        public string LocationCode { get; set; }

        public int DivisionID { get; set; }

        [Display(Name = "Division")]
        public string DivisionName { get; set; }

        public int BusinessUnitID { get; set; }

        [Display(Name = "Business Unit")]
        public string BusinessUnitName { get; set; }

        [Display(Name = "First Address")]
        public string FirstAddress { get; set; }

        [Display(Name = "Second Address")]
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