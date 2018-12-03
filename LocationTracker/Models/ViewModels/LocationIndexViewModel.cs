using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using LocationTracker.Models;

namespace LocationTracker.Models.ViewModels
{
    public class LocationIndexViewModel
    {
        public int LocationID { get; set; }

        [Display(Name = "Location Code")]
        public string LocationCode { get; set; }

        [Display(Name = "Division")]
        public string DivisionName { get; set; }

        [Display(Name = "Business Unit")]
        public string BusinessUnitName { get; set; }

        [Display(Name = "State/Province")]
        public string StateProvince { get; set; }

        public string Country { get; set; }

        public IEnumerable<Location> Locations { get; set; }
        public IEnumerable<Division> Divisions { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
    }
}
