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
using System.Collections;

namespace LocationTracker.Pages.Assessments
{
    public class CreateModel : PageModel
    {
        private readonly LocationTracker.Data.TrackerContext _context;

        public CreateModel(LocationTracker.Data.TrackerContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            AssessmentCreateVM = new AssessmentViewModel
            {
                LocationsList = new List<SelectListItem>(),
                StatusesList = new List<SelectListItem>(),
                TrueFalseNullSL = new List<SelectListItem>(),
                VendorList = new List<SelectListItem>()
            };

            await PopulateDropDownLists(_context);
            //ViewData["LocationID"] = new SelectList(_context.Location, "LocationID", "LocationCode");
            //ViewData["StatusID"] = new SelectList(_context.Status, "StatusID", "StatusName");
            return Page();
        }

        [BindProperty]
        public AssessmentViewModel AssessmentCreateVM { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await PopulateDropDownLists(_context);
                
                return Page();
            }

            var assessmentToCreate = new Assessment()
            {
                LocationID = AssessmentCreateVM.LocationID,
                VendorID = AssessmentCreateVM.VendorID,
                StatusID = AssessmentCreateVM.StatusID,
                StudyRequired = AssessmentCreateVM.StudyRequired,
                StartDate = AssessmentCreateVM.StartDate,
                EndDate = AssessmentCreateVM.EndDate,
                Comment = AssessmentCreateVM.Comment
            };

            if(await TryUpdateModelAsync<Assessment>(assessmentToCreate))
            {
                _context.Assessment.Add(assessmentToCreate);
                await _context.SaveChangesAsync();
                return RedirectToPage("../Details/", new { id = AssessmentCreateVM.LocationID });
            }

            await PopulateDropDownLists(_context);
            return Page();
        }

        public async Task PopulateLocationsDropDownList(TrackerContext _context, object selectedLocation = null)
        {
            AssessmentCreateVM.LocationsList = await _context.Location.Select(l => new SelectListItem()
            {
                Value = l.LocationID.ToString(),
                Text = l.LocationCode
            }).ToListAsync();
        }

        public async Task PopulateStatusesDropDownList(TrackerContext _context, object selectedStatus = null)
        {
            AssessmentCreateVM.StatusesList = await _context.Status.Select(s => new SelectListItem()
            {
                Value = s.StatusID.ToString(),
                Text = s.StatusName
            }).ToListAsync();
        }

        public void PopulateTrueFalseNullList(TrackerContext _context, object selectedState = null)
        {
            AssessmentCreateVM.TrueFalseNullSL = new List<SelectListItem>
            {
                new SelectListItem{Text = "N/A", Value = ""},
                new SelectListItem {Text = "Yes", Value = "true"},
                new SelectListItem {Text = "No", Value = "false"}
            };
        }
        public async Task PopulateVendorList(TrackerContext _context, object selectedVendor = null)
        {
            AssessmentCreateVM.VendorList = await _context.Vendor.Select(v => new SelectListItem()
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