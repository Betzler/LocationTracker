using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LocationTracker.Data;
using LocationTracker.Models;
using LocationTracker.Models.ViewModels;

namespace LocationTracker.Pages.Assessments
{
    public class DeleteModel : PageModel
    {
        private readonly LocationTracker.Data.TrackerContext _context;

        public DeleteModel(LocationTracker.Data.TrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AssessmentDeleteViewModel AssessmentDeleteVM { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AssessmentDeleteVM = await _context.Assessment.Select(a => new AssessmentDeleteViewModel
            {
                AssessmentID = id,
                LocationCode = a.Location.LocationCode,
                StatusName = a.Status.StatusName,
                PerformedBy = a.Vendor.VendorName,
                StartDate = a.StartDate,
                EndDate = a.EndDate

            }).FirstOrDefaultAsync(a => a.AssessmentID == id);

            if (AssessmentDeleteVM == null)
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

            var assessmentToDelete = await _context.Assessment.FirstOrDefaultAsync(a => a.AssessmentID == id);

            if (assessmentToDelete != null)
            {
                _context.Assessment.Remove(assessmentToDelete);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
