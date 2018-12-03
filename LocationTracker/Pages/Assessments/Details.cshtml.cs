using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LocationTracker.Data;
using LocationTracker.Models;

namespace LocationTracker.Pages.Assessments
{
    public class DetailsModel : PageModel
    {
        private readonly LocationTracker.Data.TrackerContext _context;

        public DetailsModel(LocationTracker.Data.TrackerContext context)
        {
            _context = context;
        }

        public Assessment Assessment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Assessment = await _context.Assessment
                .Include(a => a.Location)
                .Include(a => a.Status).FirstOrDefaultAsync(m => m.AssessmentID == id);

            if (Assessment == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
