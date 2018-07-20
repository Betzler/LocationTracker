using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocationTracker.Models
{
    public class Location
    {
        [Key]
        [Column("id")]
        public int LocationID { get; set; }

        [Required]
        [Display(Name = "Location Code")]
        [StringLength(3, ErrorMessage = "Location code cannot be longer than 3 characters.")]
        [Column("location_code")]
        public string LocationCode { get; set; }

        [Column("division_id")]
        [Display(Name = "Division ID")]
        public int? DivisionID { get; set; }

        [Column("address_id")]
        [Display(Name = "Address ID")]
        public int? AddressID { get; set; }

        public Division Division { get; set; }
        public Address Address { get; set; }
    }
}

