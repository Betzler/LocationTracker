using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocationTracker.Models;
namespace LocationTracker.Models.ViewModels
{
    public class LocationIndexViewModel
    {
        public int LocationID { get; set; }
        public string LocationCode { get; set; }
        public string DivisionName { get; set; }
        public string StateProvince { get; set; }
        public string Country { get; set; }
        public IEnumerable<Location> Locations { get; set; }
        public IEnumerable<Division> Divisions { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
    }
}
