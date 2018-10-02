using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationTracker.Models.ViewModels.PartialViews
{
    public partial class LocationPartialViewModel
    {
        public string LocationCode { get; set; }
        public int DivisionID { get; set; }
        public string DivisionName { get; set; }
    }
}
