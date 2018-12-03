using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using LocationTracker.Models;
using LocationTracker.Models.ViewModels;
using LocationTracker.Data;

namespace LocationTracker.ViewComponents
{
    public class AssessmentViewComponent : ViewComponent
    {
        private readonly LocationTracker.Data.TrackerContext _context;

        public AssessmentViewComponent(TrackerContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            return View(await GetAssessmentAsync(id));
        }

        private async Task<IList<AssessmentIndexViewModel>> GetAssessmentAsync(int id)
        {
            IList<AssessmentIndexViewModel> assessmentList = new List<AssessmentIndexViewModel>();
            assessmentList = await _context.Assessment.Where(a => a.LocationID == id).Select(a => new AssessmentIndexViewModel()
            {
                AssessmentID = a.AssessmentID,
                LocationID = a.LocationID,
                LocationCode = a.Location.LocationCode,
                StatusName = a.Status.StatusName,
                PerformedBy = a.Vendor.VendorName,
                StudyRequired = a.StudyRequired,
                StartDate = a.StartDate,
                EndDate = a.EndDate,
                Comment = a.Comment 
            }).ToListAsync();

            return (assessmentList);
        }
    }
}
