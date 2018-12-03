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
    public class StudyHistoryGraphViewComponent : ViewComponent
    {
        private readonly LocationTracker.Data.TrackerContext _context;

        public StudyHistoryGraphViewComponent(TrackerContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            return View(await GetHistoryAsync(id));
        }

        private async Task<StudyHistoryGraphViewModel> GetHistoryAsync(int id)
        {
            StudyHistoryGraphViewModel studyHistoryGraphData = new StudyHistoryGraphViewModel
            {
                UnderratedData = await _context.StudyHistory.Where(s => s.StudyID == id && s.EndDate != null).OrderBy(s => s.EndDate).Select(s => s.UnderratedIssues).ToArrayAsync(),
                ArcFlashData = await _context.StudyHistory.Where(s => s.StudyID == id && s.EndDate != null).OrderBy(s => s.EndDate).Select(s => s.ArcFlashIssues).ToArrayAsync(),
                EquipmentProtectionData = await _context.StudyHistory.Where(s => s.StudyID == id && s.EndDate != null).OrderBy(s => s.EndDate).Select(s => s.EquipmentProtectionIssues).ToArrayAsync(),
                Labels = await _context.StudyHistory.Where(s => s.StudyID == id && s.EndDate != null).OrderBy(s => s.EndDate).Select(s => s.EndDate.ToString()).ToArrayAsync()
            };

            return (studyHistoryGraphData);
        }
    }
}
