using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LocationTracker.Data;
using LocationTracker.Models;
using LocationTracker.ViewComponents;
using LocationTracker.Models.ViewModels;

namespace LocationTracker.Pages.Locations
{
    public class DetailsModel : PageModel
    {
        private readonly LocationTracker.Data.TrackerContext _context;

        public DetailsModel(LocationTracker.Data.TrackerContext context)
        {
            _context = context;
        }

        public LocationDetailsViewModel LocationDetailsVM { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LocationDetailsVM = await _context.Location.Select(l => new LocationDetailsViewModel()
            {
                LocationID = l.LocationID,
                LocationCode = l.LocationCode,
                DivisionName = l.Division.DivisionName,
                BusinessUnitName = l.BusinessUnit.BusinessUnitName,
                FirstAddress = l.Address.FirstAddress,
                SecondAddress = l.Address.SecondAddress,
                City = l.Address.City,
                StateProvince = l.Address.StateProvince,
                Country = l.Address.Country,
                PostalCode = l.Address.PostalCode,
                Lattitude = l.Address.Lattitude,
                Longitude = l.Address.Longitude

            }).FirstOrDefaultAsync(l => l.LocationID == id);

            if (LocationDetailsVM == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
