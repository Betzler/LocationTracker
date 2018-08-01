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

            var newLocation = _context.Add(new Location());
            var newAddress = _context.Add(new Address());

            newAddress.CurrentValues.SetValues(LocationCreateVM);
            newLocation.CurrentValues.SetValues(LocationCreateVM);

            newLocation.Entity.AddressID = newAddress.Entity.AddressID;

            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");

        }
    }
}