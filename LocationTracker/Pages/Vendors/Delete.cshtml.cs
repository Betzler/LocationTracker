using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LocationTracker.Data;
using LocationTracker.Models;
using LocationTracker.ViewModels;

namespace LocationTracker.Pages.Vendors
{
    public class DeleteModel : PageModel
    {
        private readonly LocationTracker.Data.TrackerContext _context;

        public DeleteModel(LocationTracker.Data.TrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public VendorViewModel VendorVM { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VendorVM = await _context.Vendor.Select(v => new VendorViewModel
            {
                VendorID = v.VendorID,
                VendorName = v.VendorName
            }).FirstOrDefaultAsync(v => v.VendorID == id);

            if (VendorVM == null)
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

            var vendorToDelete = await _context.Vendor.FindAsync(id);

            if (vendorToDelete != null)
            {
                _context.Vendor.Remove(vendorToDelete);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
