using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LocationTracker.Data;
using LocationTracker.Models;

namespace LocationTracker.Pages.Studies
{
    public class DeleteModel : PageModel
    {
        private readonly LocationTracker.Data.TrackerContext _context;

        public DeleteModel(LocationTracker.Data.TrackerContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Study = await _context.Study.FindAsync(id);

            if (Study != null)
            {
                _context.Study.Remove(Study);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
