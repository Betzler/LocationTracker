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
using Microsoft.EntityFrameworkCore;

namespace LocationTracker.Pages.Studies.Results
{
    public class CreateModel : PageModel
    {
        private readonly LocationTracker.Data.TrackerContext _context;

        public CreateModel(LocationTracker.Data.TrackerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int id)
        {
            return Page();
        }

        [BindProperty]
        public StudyResultViewModel StudyResultVM { get; set; }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var resultToCreate = new StudyResult
            {
                StudyID = id,
                UnderratedIssues = StudyResultVM.UnderratedIssues,
                ArcFlashIssues = StudyResultVM.ArcFlashIssues,
                EquipmentProtectionIssues = StudyResultVM.EquipmentProtectionIssues,
                DateCompleted = StudyResultVM.DateCompleted
            };

            _context.StudyResult.Add(resultToCreate);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Details/", new { id });
        }
    }
}