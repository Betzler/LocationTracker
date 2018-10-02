using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocationTracker.Models;
namespace LocationTracker.Models.ViewModels
{
    public class LocationDeleteViewModel
    {
        public int LocationID { get; set; }
        public string LocationCode { get; set; }
        public string DivisionName { get; set; }
        public int AddressID { get; set; }
        public string StateProvince { get; set; }
        public string Country { get; set; }
    }
}
