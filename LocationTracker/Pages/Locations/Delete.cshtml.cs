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

namespace LocationTracker.Pages.Locations
{
    public class DeleteModel : PageModel
    {
        private readonly LocationTracker.Data.TrackerContext _context;

        public DeleteModel(LocationTracker.Data.TrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LocationDeleteViewModel LocationDeleteVM { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LocationDeleteVM = await _context.Location.Select(l => new LocationDeleteViewModel()
            {
                LocationID = l.LocationID,
                LocationCode = l.LocationCode,
                DivisionName = l.Division.DivisionName,
                StateProvince = l.Address.StateProvince,
                Country = l.Address.Country
            }).FirstOrDefaultAsync(l => l.LocationID == id);

            if (LocationDeleteVM == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LocationDeleteVM = await _context.Location.Select(l => new LocationDeleteViewModel()
            {
                LocationID = l.LocationID,
                LocationCode = l.LocationCode,
                DivisionName = l.Division.DivisionName,
                AddressID = l.AddressID,
                StateProvince = l.Address.StateProvince,
                Country = l.Address.Country
            }).FirstOrDefaultAsync(l => l.LocationID == id);

            var locationToDelete = new Location
            {
                LocationID = LocationDeleteVM.LocationID,
                LocationCode = LocationDeleteVM.LocationCode,
                AddressID = LocationDeleteVM.AddressID,
                Address = new Address
                {
                    AddressID = LocationDeleteVM.AddressID,
                    StateProvince = LocationDeleteVM.StateProvince,
                    Country = LocationDeleteVM.Country
                }
                /*
                Address = new Address
                {
                    StateProvince = LocationDeleteVM.StateProvince,
                    Country = LocationDeleteVM.Country
                }*/
            };

            if (locationToDelete != null)
            {
                _context.Location.Remove(locationToDelete);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
