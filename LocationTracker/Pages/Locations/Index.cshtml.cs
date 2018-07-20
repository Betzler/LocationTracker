using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LocationTracker.Data;
using LocationTracker.Models;

namespace LocationTracker.Pages.Locations
{
    public class IndexModel : PageModel
    {
        private readonly LocationTracker.Data.TrackerContext _context;

        public IndexModel(LocationTracker.Data.TrackerContext context)
        {
            _context = context;
        }

        public IList<Location> Location { get;set; }

        public async Task OnGetAsync()
        {
            Location = await _context.Location
                .Include(l => l.Address)
                .Include(l => l.Division).ToListAsync();
        }
    }
}
