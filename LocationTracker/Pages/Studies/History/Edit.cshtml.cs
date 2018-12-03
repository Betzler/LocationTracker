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
using LocationTracker.Models.ViewModels;

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
        public StudyHistoryEditViewModel StudyHistoryEditVM { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StudyHistoryEditVM = await _context.StudyHistory.Select(sh => new StudyHistoryEditViewModel
            {
                StudyHistoryID = sh.StudyHistoryID,
                StudyTypeID = sh.StudyTypeID,
                StatusID = sh.StatusID,
                VendorID = sh.VendorID,
                StartDate = sh.StartDate,
                EndDate = sh.EndDate,
                UnderratedIssues = sh.UnderratedIssues,
                ArcFlashIssues = sh.ArcFlashIssues,
                EquipmentProtectionIssues = sh.EquipmentProtectionIssues,
                Comment = sh.Comment
            }).FirstOrDefaultAsync(m => m.StudyHistoryID == id);

            if (StudyHistoryEditVM == null)
            {
                return NotFound();
            }

           ViewData["StatusID"] = new SelectList(_context.Status, "StatusID", "StatusName");
           ViewData["StudyID"] = new SelectList(_context.Study, "StudyID", "StudyName");
           ViewData["StudyTypeID"] = new SelectList(_context.StudyType, "StudyTypeID", "StudyTypeName");
           ViewData["Vendors"] = new SelectList(_context.Vendor, "VendorID", "VendorName");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }



            var studyHistoryToEdit =  await _context.StudyHistory.FirstOrDefaultAsync(sh => sh.StudyHistoryID == StudyHistoryEditVM.StudyHistoryID);

            studyHistoryToEdit.StudyHistoryID = StudyHistoryEditVM.StudyHistoryID;
            studyHistoryToEdit.StudyID = StudyHistoryEditVM.StudyID;
            studyHistoryToEdit.StatusID = StudyHistoryEditVM.StatusID;
            studyHistoryToEdit.VendorID = StudyHistoryEditVM.VendorID;
            studyHistoryToEdit.StartDate = StudyHistoryEditVM.StartDate;
            studyHistoryToEdit.EndDate = StudyHistoryEditVM.EndDate;
            studyHistoryToEdit.ExpirationDate = CheckExpirationDate(StudyHistoryEditVM.EndDate);
            studyHistoryToEdit.UnderratedIssues = StudyHistoryEditVM.UnderratedIssues;
            studyHistoryToEdit.ArcFlashIssues = StudyHistoryEditVM.ArcFlashIssues;
            studyHistoryToEdit.EquipmentProtectionIssues = StudyHistoryEditVM.EquipmentProtectionIssues;

            _context.Attach(studyHistoryToEdit).State = EntityState.Modified;
            if(await TryUpdateModelAsync<StudyHistory>(studyHistoryToEdit, "StudyHistory",
                sh => sh.StatusID,
                sh => sh.VendorID,
                sh => sh.StudyTypeID,
                sh => sh.StartDate,
                sh => sh.EndDate,
                sh => sh.ExpirationDate,
                sh => sh.UnderratedIssues,
                sh => sh.ArcFlashIssues,
                sh => sh.EquipmentProtectionIssues))
            {
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudyHistoryExists(studyHistoryToEdit.StudyHistoryID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
      

            return RedirectToPage("../Details/", new { id = StudyHistoryEditVM.StudyID });
        }

        private bool StudyHistoryExists(int id)
        {
            return _context.StudyHistory.Any(e => e.StudyHistoryID == id);
        }

        private DateTime? CheckExpirationDate(DateTime? completionDate)
        {
            if (completionDate != null)
            {
                return completionDate.Value.AddYears(5);
            }

            return null;
        }
    }
}
