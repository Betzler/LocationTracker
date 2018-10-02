using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LocationTracker.Data;
using LocationTracker.Models;
using LocationTracker.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LocationTracker.Pages.Studies
{
    public class LocationCodePageModel : PageModel
    {
        public MultiSelectList LocationCodeMSL { get; set; }

        public async Task PopulateLocationCodeMSL(TrackerContext _context, IList<StudyCreateLocationViewModel> selectedLocationsList)
        {
            IList<StudyCreateLocationViewModel> locationCodeList = new List<StudyCreateLocationViewModel>();

            locationCodeList = await _context.Location.Select(l => new StudyCreateLocationViewModel()
            {
                LocationID = l.LocationID,
                LocationCode = l.LocationCode,
                DivisionName = l.Division.DivisionName
            }).ToListAsync();

            LocationCodeMSL = new MultiSelectList(locationCodeList, "LocationID", "LocationCode", selectedLocationsList);
        }
    }
}
