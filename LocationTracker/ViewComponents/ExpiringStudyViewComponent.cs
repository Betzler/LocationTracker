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
    public class ExpiringStudyViewComponent : ViewComponent
    {
        private readonly LocationTracker.Data.TrackerContext _context;

        public ExpiringStudyViewComponent(TrackerContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }

        private async Task<IList<ExpiringStudyViewModel>> GetExpiringStudyAsync()
        {
            IList<ExpiringStudyViewModel> expiringStudyList = new List<ExpiringStudyViewModel>();
            expiringStudyList = await _context.Study.Include(es => es.StudyResults).Select(es => new ExpiringStudyViewModel()
            {
                StudyID = es.StudyID,
                StudyName = es.StudyName,

            }).ToListAsync();

            return (expiringStudyList);
        }
    }
}
