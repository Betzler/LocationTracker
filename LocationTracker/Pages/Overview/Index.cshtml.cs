using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LocationTracker.Data;
using LocationTracker.Models;
using LocationTracker.Models.ViewModels;

namespace LocationTracker.Pages.Overview
{
    public class IndexModel : PageModel
    {
        private readonly LocationTracker.Data.TrackerContext _context;

        public IndexModel(LocationTracker.Data.TrackerContext context)
        {
            _context = context;
        }

        public OverviewIndexViewModel OverviewIndexVM { get; set; }

        public async Task OnGetAsync()
        {
            OverviewIndexVM = new OverviewIndexViewModel
            {
                OverviewBusinessUnitLocationsIndexVM = new List<OverviewBusinessUnitLocationsIndexViewModel>(),
                OverviewDivisionLocationsIndexVM = new List<OverviewDivisionLocationsIndexViewModel>()
            };
            OverviewIndexVM.StudiesTotal = await _context.Study.CountAsync();


            OverviewIndexVM.LocationsTotal = await _context.Location.CountAsync();

        }
    }
}
