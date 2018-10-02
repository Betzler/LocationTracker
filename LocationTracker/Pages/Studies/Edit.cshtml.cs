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

namespace LocationTracker.Pages.Studies
{
    public class EditModel : PageModel
    {
        private readonly LocationTracker.Data.TrackerContext _context;

        public EditModel(LocationTracker.Data.TrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Study Study { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Study = await _context.Study.FirstOrDefaultAsync(m => m.StudyID == id);

            if (Study == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Study).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudyExists(Study.StudyID))
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

        private bool StudyExists(int id)
        {
            return _context.Study.Any(e => e.StudyID == id);
        }
    }
}
