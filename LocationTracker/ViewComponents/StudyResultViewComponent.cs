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
    public class StudyResultViewComponent : ViewComponent
    {
        private readonly LocationTracker.Data.TrackerContext _context;

        public StudyResultViewComponent(TrackerContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            return View(await GetResultAsync(id));
        }

        private async Task<IList<StudyResultIndexViewModel>> GetResultAsync(int id)
        {
            IList<StudyResultIndexViewModel> studyResultList = new List<StudyResultIndexViewModel>();
            studyResultList = await _context.StudyResult.Where(s => s.StudyHistory.StudyID == id).Select(s => new StudyResultIndexViewModel()
            {
               StudyHistoryID = s.StudyHistoryID,
               StudyResultID = s.StudyResultID,
               UnderratedIssues = s.UnderratedIssues,
               ArcFlashIssues = s.ArcFlashIssues,
               EquipmentProtectionIssues = s.EquipmentProtectionIssues
                
            }).ToListAsync();

            return (studyResultList);
        }
    }
}
