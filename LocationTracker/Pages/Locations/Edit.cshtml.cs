using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LocationTracker.Data;
using LocationTracker.Models;
using LocationTracker.Models.ViewModels;

namespace LocationTracker.Pages.Locations
{
    public class EditModel : PageModel
    {
        private readonly LocationTracker.Data.TrackerContext _context;

        public EditModel(LocationTracker.Data.TrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LocationEditViewModel LocationEditVM { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var locationToGet = await _context.Location.Include(l => l.Address).Include(l => l.Division).AsNoTracking().SingleOrDefaultAsync(l => l.LocationID == id);

            LocationEditVM = await _context.Location.Select(l => new LocationEditViewModel()
            {
                LocationID = l.LocationID,
                LocationCode = l.LocationCode,
                AddressID = l.AddressID,
                DivisionID = l.DivisionID,
                StateProvince = l.Address.StateProvince,
                Country = l.Address.Country

            }).FirstOrDefaultAsync(l => l.LocationID == id);
            
            if (LocationEditVM == null)
            {
                return NotFound();
            }

            ViewData["AddressID"] = new SelectList(_context.Address, "AddressID", "Country");
            ViewData["DivisionID"] = new SelectList(_context.Division, "DivisionID", "DivisionName");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var locationToEdit = await _context.Location.AsTracking().Include(l => l.Address).FirstOrDefaultAsync(l => l.LocationID == id);

            if(locationToEdit != null)
            {
                locationToEdit.LocationCode = LocationEditVM.LocationCode;
                locationToEdit.DivisionID = LocationEditVM.DivisionID;
                locationToEdit.Address.StateProvince = LocationEditVM.StateProvince;
                locationToEdit.Address.Country = LocationEditVM.Country;
            }
            else
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Location>(locationToEdit,"location", l=>l.LocationCode, 
                l=> l.AddressID, l => l.DivisionID))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool LocationExists(int id)
        {
            return _context.Location.Any(e => e.LocationID == id);
        }
    }
}
