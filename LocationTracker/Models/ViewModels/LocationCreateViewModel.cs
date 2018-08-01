﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocationTracker.Models;
namespace LocationTracker.Models.ViewModels
{
    public class LocationCreateViewModel
    {

        public string LocationCode { get; set; }
        public int DivisionID { get; set; }
        public string DivisionName { get; set; }
        public string FirstAddress { get; set; }
        public string SecondAddress { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public float? Lattitude { get; set; }
        public float? Longitude { get; set; }
    }
}