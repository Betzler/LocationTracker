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

namespace LocationTracker.Pages.Studies
{
    public class IndexModel : PageModel
    {
        private readonly LocationTracker.Data.TrackerContext _context;

        public IndexModel(LocationTracker.Data.TrackerContext context)
        {
            _context = context;
        }

        public IList<StudyIndexViewModel> StudyIndexVM { get;set; }

        public async Task OnGetAsync()
        {
            StudyIndexVM = await _context.Study.Select(s => new StudyIndexViewModel
            {
                StudyID = s.StudyID,
                StudyName = s.StudyName
            }).ToListAsync();
        }
    }
}
