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
    public class IndexModel : PageModel
    {
        private readonly LocationTracker.Data.TrackerContext _context;

        public IndexModel(LocationTracker.Data.TrackerContext context)
        {
            _context = context;
        }

        public IList<StudyHistoryIndexViewModel> StudyHistoryIndexVM { get;set; }

        public async Task OnGetAsync()
        {
            StudyHistoryIndexVM = await _context.StudyHistory.Select(s => new StudyHistoryIndexViewModel
            {
                StudyHistoryID = s.StudyHistoryID,
                StudyTypeID = s.StudyTypeID,
                StatusID = s.StatusID,
                StartDate = s.StartDate,
                EndDate = s.EndDate
            }).ToListAsync();
        }
    }
}
