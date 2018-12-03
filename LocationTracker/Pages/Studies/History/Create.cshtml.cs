using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LocationTracker.Data;
using LocationTracker.Models;
using LocationTracker.Models.ViewModels;

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
            ViewData["Vendors"] = new SelectList(_context.Vendor, "VendorID", "VendorName");
            return Page();
        }

        [BindProperty]
        public StudyHistoryCreateViewModel StudyHistoryCreateVM { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var studyHistoryToCreate = new StudyHistory()
            {
                StudyID = StudyHistoryCreateVM.StudyID,
                StatusID = StudyHistoryCreateVM.StatusID,
                StudyTypeID = StudyHistoryCreateVM.StudyTypeID,
                VendorID = StudyHistoryCreateVM.VendorID,
                UnderratedIssues = StudyHistoryCreateVM.UnderratedIssues,
                ArcFlashIssues = StudyHistoryCreateVM.ArcFlashIssues,
                EquipmentProtectionIssues = StudyHistoryCreateVM.EquipmentProtectionIssues,
                StartDate = StudyHistoryCreateVM.StartDate,
                EndDate = StudyHistoryCreateVM.EndDate,
                ExpirationDate = CheckExpirationDate(StudyHistoryCreateVM.EndDate),
                Comment = StudyHistoryCreateVM.Comment
            };
            _context.StudyHistory.Add(studyHistoryToCreate);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Details/", new { id = StudyHistoryCreateVM.StudyID });
        }

        private DateTime? CheckExpirationDate(DateTime? completionDate)
        {
            if(completionDate != null)
            {
                return completionDate.Value.AddYears(5);
            }

            return null;
        }
    }
}