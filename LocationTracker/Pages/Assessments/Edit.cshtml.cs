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
using LocationTracker.ViewModels;
using LocationTracker.Models.ViewModels;

namespace LocationTracker.Pages.Assessments
{
    public class EditModel : PageModel
    {
        private readonly LocationTracker.Data.TrackerContext _context;

        public EditModel(LocationTracker.Data.TrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AssessmentViewModel AssessmentVM { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AssessmentVM = await _context.Assessment.Select(a => new AssessmentViewModel
            {
                AssessmentID = a.AssessmentID,
                LocationID = a.LocationID,
                StatusID = a.StatusID,
                VendorID = a.VendorID,
                StudyRequired = a.StudyRequired,
                StartDate = a.StartDate,
                EndDate = a.EndDate,
                Comment = a.Comment

            }).Where(a => a.AssessmentID == id).SingleOrDefaultAsync();

            if (AssessmentVM == null)
            {
                return NotFound();
            }
            await PopulateDropDownLists(_context);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await PopulateDropDownLists(_context);
                return Page();
            }

            var assessmentToEdit = new Assessment
            {
                AssessmentID = AssessmentVM.AssessmentID,
                LocationID = AssessmentVM.LocationID,
                StatusID = AssessmentVM.StatusID,
                VendorID = AssessmentVM.VendorID,
                StudyRequired = AssessmentVM.StudyRequired,
                StartDate = AssessmentVM.StartDate,
                EndDate = AssessmentVM.EndDate,
                Comment = AssessmentVM.Comment,
            };

            try
            {
                _context.Update(assessmentToEdit);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssessmentExists(assessmentToEdit.AssessmentID))
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

        private bool AssessmentExists(int id)
        {
            return _context.Assessment.Any(e => e.AssessmentID == id);
        }

        public async Task PopulateLocationsDropDownList(TrackerContext _context, object selectedLocation = null)
        {
            AssessmentVM.LocationsList = await _context.Location.Select(l => new SelectListItem()
            {
                Value = l.LocationID.ToString(),
                Text = l.LocationCode
            }).ToListAsync();
        }

        public async Task PopulateStatusesDropDownList(TrackerContext _context, object selectedStatus = null)
        {
            AssessmentVM.StatusesList = await _context.Status.Select(s => new SelectListItem()
            {
                Value = s.StatusID.ToString(),
                Text = s.StatusName
            }).ToListAsync();
        }

        public void PopulateTrueFalseNullList(TrackerContext _context, object selectedState = null)
        {
            AssessmentVM.TrueFalseNullSL = new List<SelectListItem>
            {
                new SelectListItem{Text = "N/A", Value = ""},
                new SelectListItem {Text = "Yes", Value = "true"},
                new SelectListItem {Text = "No", Value = "false"}
            };
        }
        public async Task PopulateVendorList(TrackerContext _context, object selectedVendor = null)
        {
            AssessmentVM.VendorList = await _context.Vendor.Select(v => new SelectListItem()
            {
                Value = v.VendorID.ToString(),
                Text = v.VendorName
            }).ToListAsync();

        }
        public async Task PopulateDropDownLists(TrackerContext _context, object selectedLocation = null, object selectedStatus = null, object selectedState = null, object selectedVendor = null)
        {
            await PopulateLocationsDropDownList(_context, selectedLocation);
            await PopulateStatusesDropDownList(_context, selectedStatus);
            await PopulateVendorList(_context, selectedVendor);
            PopulateTrueFalseNullList(_context, selectedState);
        }
    }
}
