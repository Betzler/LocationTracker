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
            StudyIndexVM = await _context.Study.Include(s => s.LocationStudies).ThenInclude(s => s.Location).Select(s => new StudyIndexViewModel
            {
                StudyID = s.StudyID,
                StudyName = s.StudyName,
                LastStudyDate = s.StudyResults.OrderByDescending(sr => sr.DateCompleted).Select(sr => sr.DateCompleted).FirstOrDefault(),
                ExpireDate = CheckValidDate(s.StudyResults.OrderByDescending(sr => sr.DateCompleted).Select(sr => sr.DateCompleted).FirstOrDefault()),
                LocationVM = s.LocationStudies.Select(ls => new StudyIndexLocationViewModel
                {
                    LocationID = ls.LocationID,
                    LocationName = ls.Location.LocationCode,
                    DivisionName = ls.Location.Division.DivisionName,
                    LocationFullName = ls.Location.LocationCode + " " + ls.Location.Division.DivisionName
                }).ToList()
            }).ToListAsync();
            
        }

        private DateTime? CheckValidDate(DateTime? date)
        {
            if (date == null)
            {
                return null;
            }
            return date.Value.AddYears(5);
        }
    }
}
