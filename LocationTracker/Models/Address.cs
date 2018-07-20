using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocationTracker.Models
{
    public class Address
    {
        [Key]
        [Column("id")]

        public int AddressID { get; set; }

        [Display(Name = "Street Address 1")]
        [Column("address_1")]
        [StringLength(50, ErrorMessage = "Street address cannot be longer than 50 characters.")]

        public string FirstAddress { get; set; }

        [Display(Name = "Street Address 2")]
        [Column("address_2")]
        [StringLength(50, ErrorMessage = "Street address cannot be longer than 50 characters.")]

        public string SecondAddress { get; set; }

        [Display(Name = "City")]
        [Column("city")]
        [StringLength(50, ErrorMessage = "City name cannot be longer than 50 characters.")]

        public string City { get; set; }

        [Display(Name = "State/Province")]
        [Column("state_province")]
        public string StateProvince { get; set; }

        [Required]
        [Display(Name = "Country")]
        [Column("country")]
        public string Country { get; set; }

        [Display(Name = "Lattitude")]
        [Column("lattitude")]
        public float Lattitude { get; set; }

        [Display(Name = "Longitude")]
        [Column("longitude")]
        public float Longitude { get; set; }

        public virtual Location Location { get; set; }
    }
}
