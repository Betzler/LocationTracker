using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LocationTracker.Data;
using LocationTracker.Models;
using LocationTracker.Models.ViewModels;

namespace LocationTracker.Pages.Studies
{
    public class EditModel : LocationCodePageModel
    {
        private readonly LocationTracker.Data.TrackerContext _context;

        public EditModel(LocationTracker.Data.TrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public StudyEditViewModel StudyEditVM { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StudyEditVM = await _context.Study.Include(s => s.LocationStudies).Select(s => new StudyEditViewModel
            {
                StudyID = s.StudyID,
                StudyName = s.StudyName,
                StudySize = s.StudySize,
                SelectedLocations = _context.LocationStudy.Where(ls => ls.StudyID == s.StudyID).Select(ls => ls.LocationID).ToList()
            }).FirstOrDefaultAsync(ls => ls.StudyID == id);

            await PopulateLocationCodeMSL(_context);

            if (StudyEditVM == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var studyToEdit = _context.Study.Include(s => s.LocationStudies).FirstOrDefault(s => s.StudyID == StudyEditVM.StudyID);
           
            //studyToEdit.LocationStudies = await _context.LocationStudy.Where(ls => ls.StudyID == StudyEditVM.StudyID).ToListAsync();

            _context.Attach(studyToEdit).State = EntityState.Modified;

            if (studyToEdit == null)
            {
                return NotFound();
            }

            studyToEdit.StudyID = StudyEditVM.StudyID;
            studyToEdit.StudyName = StudyEditVM.StudyName;
            studyToEdit.StudySize = StudyEditVM.StudySize;

            //Remove LocationStudy if it has not been selected
            studyToEdit.LocationStudies.Where(ls => !StudyEditVM.SelectedLocations.Contains(ls.LocationID))
                .ToList().ForEach(remls => studyToEdit.LocationStudies.Remove(remls));

            //Add LocationStudy if it remains in the list after excluding prior location studies

            var existingLocationStudies = studyToEdit.LocationStudies.Select(ls => ls.LocationID);
            var nonExistingLocationStudies = StudyEditVM.SelectedLocations.Except(existingLocationStudies).ToList();            

            foreach (int locationStudy in nonExistingLocationStudies)
                studyToEdit.LocationStudies.Add(new LocationStudy
                {
                    StudyID = StudyEditVM.StudyID,
                    LocationID = locationStudy
                });

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudyExists(studyToEdit.StudyID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StudyExists(int id)
        {
            return _context.Study.Any(e => e.StudyID == id);
        }
    }
}
