using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationTracker.Models.ViewModels
{
    public partial class OverviewDivisionLocationsIndexViewModel
    {
        public string DivisionName { get; set; }
        public int DivisionTotal { get; set; }
    }

    public partial class OverviewBusinessUnitLocationsIndexViewModel
    {
        public string BusinessUnitName { get; set; }
        public int BusinessUnitTotal { get; set; }
    }

    public partial class OverviewIndexViewModel
    {
        public int LocationsTotal { get; set; }
        public int StudiesTotal { get; set; }

        public IList<OverviewDivisionLocationsIndexViewModel> OverviewDivisionLocationsIndexVM { get; set; }
        public IList<OverviewBusinessUnitLocationsIndexViewModel> OverviewBusinessUnitLocationsIndexVM { get; set; }
    }
}
