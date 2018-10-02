using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationTracker.Models.ViewModels
{
    public class LocationEditViewModel
    {
        public int LocationID { get; set; }
        public int? DivisionID { get; set; }
        public int AddressID { get; set; }
        public string DivisionName { get; set; }
        public string LocationCode { get; set; }
        public string StateProvince { get; set; }
        public string Country { get; set; }

        public Location Location { get; set; }
        public IEnumerable<Division> Divisions { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
    }
}
