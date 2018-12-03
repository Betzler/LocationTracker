using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace LocationTracker.Models.ViewModels
{
    public class LocationEditViewModel
    {
        public int LocationID { get; set; }
        public string LocationCode { get; set; }
        public int? DivisionID { get; set; }
        public string DivisionName { get; set; }
        public int? BusinessUnitID { get; set; }
        public string BusinessUnitName { get; set; }
        public int AddressID { get; set; }

        [Display(Name = "First Address")]
        public string FirstAddress { get; set; }

        [Display(Name = "Second Address")]
        public string SecondAddress { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State/Province")]
        public string StateProvince { get; set; }

        public string Country { get; set; }

        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Display(Name = "Lattitude")]
        public float? Lattitude { get; set; }

        [Display(Name = "Longitude")]
        public float? Longitude { get; set; }


        public Location Location { get; set; }
        public IEnumerable<Division> Divisions { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
    }
}
