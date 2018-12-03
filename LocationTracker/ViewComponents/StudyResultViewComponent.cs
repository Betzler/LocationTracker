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
            ViewData.Add("StudyID", id);


            return View(await GetResultAsync(id));
        }

        private async Task<IList<StudyResultViewModel>> GetResultAsync(int id)
        {
            IList<StudyResultViewModel> studyResultList = new List<StudyResultViewModel>();

            studyResultList = await _context.StudyResult.Where(s => s.StudyID == id).OrderByDescending(s => s.DateCompleted).Select(s => new StudyResultViewModel()
            {
               StudyResultID = s.StudyResultID,
               UnderratedIssues = s.UnderratedIssues,
               ArcFlashIssues = s.ArcFlashIssues,
               EquipmentProtectionIssues = s.EquipmentProtectionIssues,
               DateCompleted = s.DateCompleted
               
            }).ToListAsync();

            return (studyResultList);
        }
    }
}
