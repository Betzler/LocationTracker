﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly LocationTracker.Data.TrackerContext _context;

        public DetailsModel(LocationTracker.Data.TrackerContext context)
        {
            _context = context;
        }

        public Location Location { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Location = await _context.Location
                .Include(l => l.Address)
                .Include(l => l.Division).FirstOrDefaultAsync(m => m.LocationID == id);

            if (Location == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}