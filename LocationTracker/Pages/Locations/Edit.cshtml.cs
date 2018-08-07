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

            //var getEditLocation = await _context.Location.Include(l => l.Address).Include(l => l.Division).SingleOrDefaultAsync(l => l.LocationID == id);
            LocationEditVM = await _context.Location.Select(l => new LocationEditViewModel
            {
                LocationID = l.LocationID,
                LocationCode = l.LocationCode,
                DivisionName = l.Division.DivisionName,
                StateProvince = l.Address.StateProvince,
                Country = l.Address.Country

            }).SingleOrDefaultAsync(l => l.LocationID == id);

            if (LocationEditVM == null)
            {
                return NotFound();
            }

            ViewData["AddressID"] = new SelectList(_context.Address, "AddressID", "Country");
            ViewData["DivisionID"] = new SelectList(_context.Division, "DivisionID", "DivisionName");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(LocationEditVM).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationExists(LocationEditVM.LocationID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LocationExists(int id)
        {
            return _context.Location.Any(e => e.LocationID == id);
        }
    }
}
