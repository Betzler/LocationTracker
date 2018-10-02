using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LocationTracker.Data;
using LocationTracker.Models;

namespace LocationTracker.Pages.Studies.History
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
        ViewData["StatusID"] = new SelectList(_context.Status, "StatusID", "StatusName");
        ViewData["StudyID"] = new SelectList(_context.Study, "StudyID", "StudyName");
        ViewData["StudyTypeID"] = new SelectList(_context.StudyType, "StudyTypeID", "StudyTypeName");
            return Page();
        }

        [BindProperty]
        public StudyHistory StudyHistory { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.StudyHistory.Add(StudyHistory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}