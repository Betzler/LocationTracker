using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LocationTracker.Data;
using LocationTracker.Models;
using LocationTracker.ViewModels;

namespace LocationTracker.Pages.Vendors
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
            return Page();
        }

        [BindProperty]
        public VendorViewModel VendorVM { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var vendorToCreate = new Vendor
            {
                VendorNumber = VendorVM.VendorNumber,
                VendorName = VendorVM.VendorName
            };

            _context.Vendor.Add(vendorToCreate);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}