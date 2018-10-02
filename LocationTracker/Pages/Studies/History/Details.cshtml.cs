using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LocationTracker.Data;
using LocationTracker.Models;

namespace LocationTracker.Pages.Studies.History
{
    public class DetailsModel : PageModel
    {
        private readonly LocationTracker.Data.TrackerContext _context;

        public DetailsModel(LocationTracker.Data.TrackerContext context)
        {
            _context = context;
        }

        public StudyHistory StudyHistory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StudyHistory = await _context.StudyHistory
                .Include(s => s.Status)
                .Include(s => s.Study)
                .Include(s => s.StudyType).FirstOrDefaultAsync(m => m.StudyHistoryID == id);

            if (StudyHistory == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
