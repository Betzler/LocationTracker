using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LocationTracker.Data;
using LocationTracker.Models.ViewModels;
using LocationTracker.Models;

namespace LocationTracker.Pages.Locations
{
    public class CreateModel : PageModel
    {
        private readonly LocationTracker.Data.TrackerContext _context;

        public CreateModel(LocationTracker.Data.TrackerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AddressID"] = new SelectList(_context.Address, "AddressID", "Country");
        ViewData["DivisionID"] = new SelectList(_context.Division, "DivisionID", "DivisionName");
            return Page();
        }

        [BindProperty]
        public LocationCreateViewModel LocationCreateVM { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var newLocation = new LocationCreateViewModel();
            if(await TryUpdateModelAsync<LocationCreateViewModel>(
                newLocation,
                "Location",
                l => l.LocationCode,
                l => l.DivisionName,
                l => l.FirstAddress,
                l => l.SecondAddress,
                l => l.City,
                l => l.StateProvince,
                l => l.Country,
                l => l.PostalCode,
                l => l.Lattitude,
                l => l.Longitude
                ))
            {
                // _context.LocationCreateViewModel.Add(newLocation);

                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            return Page();

        }
    }
}