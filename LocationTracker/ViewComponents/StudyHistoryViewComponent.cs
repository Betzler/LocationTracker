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
    public class StudyHistoryViewComponent : ViewComponent
    {
        private readonly LocationTracker.Data.TrackerContext _context;

        public StudyHistoryViewComponent(TrackerContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            return View(await GetHistoryAsync(id));
        }

        private async Task<IList<StudyHistoryIndexViewModel>> GetHistoryAsync(int id)
        {
            IList<StudyHistoryIndexViewModel> studyHistoryList = new List<StudyHistoryIndexViewModel>();
            studyHistoryList = await _context.StudyHistory.Where(s => s.StudyID == id).Select(s => new StudyHistoryIndexViewModel()
            {
                StudyHistoryID = s.StudyHistoryID,
                StudyTypeID = s.StudyTypeID,
                StudyTypeName = s.StudyType.StudyTypeName,
                StatusID = s.StatusID,
                StatusName = s.Status.StatusName,
                StartDate = s.StartDate,
                EndDate = s.EndDate
                
            }).ToListAsync();

            return (studyHistoryList);
        }
    }
}
