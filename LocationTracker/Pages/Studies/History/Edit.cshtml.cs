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

namespace LocationTracker.Pages.Studies.History
{
    public class EditModel : PageModel
    {
        private readonly LocationTracker.Data.TrackerContext _context;

        public EditModel(LocationTracker.Data.TrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["StatusID"] = new SelectList(_context.Status, "StatusID", "StatusName");
           ViewData["StudyID"] = new SelectList(_context.Study, "StudyID", "StudyName");
           ViewData["StudyTypeID"] = new SelectList(_context.StudyType, "StudyTypeID", "StudyTypeName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(StudyHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudyHistoryExists(StudyHistory.StudyHistoryID))
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

        private bool StudyHistoryExists(int id)
        {
            return _context.StudyHistory.Any(e => e.StudyHistoryID == id);
        }
    }
}
