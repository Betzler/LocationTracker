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

namespace LocationTracker.Pages.Studies.History
{
    public class DeleteModel : PageModel
    {
        private readonly LocationTracker.Data.TrackerContext _context;

        public DeleteModel(LocationTracker.Data.TrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public StudyHistoryDeleteViewModel StudyHistoryDeleteVM { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            StudyHistoryDeleteVM = await _context.StudyHistory.Select(s => new StudyHistoryDeleteViewModel
            {
                StudyHistoryID = s.StudyHistoryID,
                StudyName = s.Study.StudyName,
                StudyTypeID = s.StudyTypeID,
                StudyTypeName = s.StudyType.StudyTypeName,
                StatusID = s.StatusID,
                StatusName = s.Status.StatusName
            }).FirstOrDefaultAsync(s => s.StudyHistoryID == id);


            if (StudyHistoryDeleteVM == null)
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

            var studyHistoryToDelete = new StudyHistory
            {
                StudyHistoryID = StudyHistoryDeleteVM.StudyHistoryID,
                StudyTypeID = StudyHistoryDeleteVM.StudyTypeID,
                StudyID = StudyHistoryDeleteVM.StudyHistoryID
            };


            if (StudyHistoryDeleteVM != null)
            {
                _context.StudyHistory.Remove(studyHistoryToDelete);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
