using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LocationTracker.ViewModels
{
    public class VendorViewModel
    {
        public int VendorID { get; set; }

        [Display(Name = "Vendor Number")]
        public int VendorNumber { get; set; }

        [Display(Name = "Name")]
        public string VendorName { get; set; }

    }
}
