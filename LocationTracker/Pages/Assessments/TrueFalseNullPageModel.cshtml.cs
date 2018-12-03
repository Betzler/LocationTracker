using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LocationTracker.Data;

namespace LocationTracker.Pages.Assessments
{ 
    public class TrueFalseNullPageModel : PageModel
    {
        public SelectList TrueFalseNullSL { get; set; }

        public void PopulateTrueFalseNullSL(TrackerContext _context, object selectedOption = null)
        {
            var options = new List<SelectListItem>
            {
                new SelectListItem { Text = "False", Value = "0"},
                new SelectListItem { Text = "True", Value = "1"},
                new SelectListItem { Text = "N/A", Value = null}
            };

            TrueFalseNullSL = new SelectList(options, selectedOption);
        }
    }
}
