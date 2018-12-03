using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LocationTracker.Data;
using LocationTracker.Models;
using LocationTracker.ViewComponents;

namespace LocationTracker.Pages.Studies
{
    public class DetailsModel : PageModel
    {
        private readonly LocationTracker.Data.TrackerContext _context;

        public DetailsModel(LocationTracker.Data.TrackerContext context)
        {
            _context = context;
        }

        public Study Study { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Study = await _context.Study.FirstOrDefaultAsync(m => m.StudyID == id);
            var studyHistoryVC = new StudyHistoryViewComponent(_context).InvokeAsync(Study.StudyID);
            if (Study == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
