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
    public class IndexModel : PageModel
    {
        private readonly LocationTracker.Data.TrackerContext _context;

        public IndexModel(LocationTracker.Data.TrackerContext context)
        {
            _context = context;
        }

        public IList<AssessmentIndexViewModel> AssessmentIndexVM { get;set; }

        public async Task OnGetAsync()
        {
            AssessmentIndexVM = await _context.Assessment.Select(a => new AssessmentIndexViewModel
            {
                AssessmentID = a.AssessmentID,
                LocationCode = a.Location.LocationCode,
                StatusName = a.Status.StatusName,
                StudyRequired = a.StudyRequired,
                PerformedBy = a.Vendor.VendorName,
                StartDate = a.StartDate,
                EndDate = a.EndDate,
                Comment = a.Comment
            }).ToListAsync();
        }
    }
}
