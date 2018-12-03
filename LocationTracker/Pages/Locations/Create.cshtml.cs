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
using Microsoft.EntityFrameworkCore;

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
            ViewData["DivisionID"] = new SelectList(_context.Division, "DivisionID", "DivisionName");
            ViewData["BusinessUnitID"] = new SelectList(_context.BusinessUnit, "BusinessUnitID", "BusinessUnitName");
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
            /* Changed to allow location creation with only knowing the country of origin.
             */

            var newLocation = new Location
            {
                LocationCode = LocationCreateVM.LocationCode,
                DivisionID = LocationCreateVM.DivisionID,
                BusinessUnitID = LocationCreateVM.BusinessUnitID,
                Address = new Address
                {
                    StateProvince = LocationCreateVM.StateProvince,
                    Country = LocationCreateVM.Country
                }
            };
            
            _context.Location.Add(newLocation);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");

            //_context.Add(new Location());
            //newLocation.Context.Add(new Address());
            //newLocation.CurrentValues.SetValues(LocationCreateVM);

            //await newLocation.Context.SaveChangesAsync();
        }

    }
}