using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LocationTracker.Data;
using LocationTracker.Models;
using LocationTracker.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LocationTracker.Pages.Studies
{
    public class CreateModel : LocationCodePageModel
    {
        private readonly LocationTracker.Data.TrackerContext _context;

        public CreateModel(LocationTracker.Data.TrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public StudyCreateViewModel StudyCreateVM { get; set; }

        public async Task OnGetAsync()
        {
            var StudyCreateVM = new StudyCreateViewModel();

            await PopulateLocationCodeMSL(_context, StudyCreateVM.SelectedLocationsList);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var studyToCreate = new Study
            {
                StudyName = StudyCreateVM.StudyName,
                StudySize = StudyCreateVM.StudySize,
            };

            if (StudyCreateVM.SelectedLocations != null)
            {
                studyToCreate.LocationStudies = new List<LocationStudy>();

                foreach(int selectedLocation in StudyCreateVM.SelectedLocations)
                {
                    studyToCreate.LocationStudies.Add(new LocationStudy()
                    {
                        StudyID = studyToCreate.StudyID,
                        LocationID = selectedLocation
                    });
                }
            }

            _context.Study.Add(studyToCreate);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}