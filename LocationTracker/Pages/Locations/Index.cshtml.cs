using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LocationTracker.Data;
using LocationTracker.Models.ViewModels;

namespace LocationTracker.Pages.Locations
{
    public class IndexModel : PageModel
    {
        private readonly LocationTracker.Data.TrackerContext _context;

        public IndexModel(LocationTracker.Data.TrackerContext context)
        {
            _context = context;
        }

        public IList<LocationIndexViewModel> LocationIndexVM { get; set; }

        public async Task OnGetAsync()
        {
            LocationIndexVM = await _context.Location.Select(l => new LocationIndexViewModel
            {
                LocationID = l.LocationID,
                LocationCode = l.LocationCode,
                DivisionName = l.Division.DivisionName,
                StateProvince = l.Address.StateProvince,
                Country = l.Address.Country

            }).ToListAsync();

        }
    }
}
