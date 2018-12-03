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
    public class IndexModel : PageModel
    {
        private readonly LocationTracker.Data.TrackerContext _context;

        public IndexModel(LocationTracker.Data.TrackerContext context)
        {
            _context = context;
        }

        public IList<VendorViewModel> VendorVM { get;set; }

        public async Task OnGetAsync()
        {
            VendorVM = await _context.Vendor.Select(v => new VendorViewModel
            {
                VendorID = v.VendorID,
                VendorNumber = v.VendorNumber,
                VendorName = v.VendorName
            }).ToListAsync();
        }
    }
}
