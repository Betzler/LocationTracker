using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocationTracker.Models
{
    public class Division
    {
        [Key]
        [Column("id")]
        public int DivisionID { get; set; }

        [Required]
        [Display(Name = "Division")]
        [Column("division_name")]
        public string DivisionName { get; set; }

        public virtual Location Location { get; set; }
    }
}
