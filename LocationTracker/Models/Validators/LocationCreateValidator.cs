using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using LocationTracker.Models.ViewModels;

namespace LocationTracker.Models.Validators
{
    public class LocationCreateVMValidator : AbstractValidator<LocationCreateViewModel>
    {
        public LocationCreateVMValidator()
        {
            RuleFor(locationVM => locationVM.LocationCode).Length(3).NotEmpty().WithName("Location Code");
            RuleFor(locationVM => locationVM.StateProvince).NotEmpty().WithName("State/Province");
            RuleFor(locationVM => locationVM.Country).Length(3).NotEmpty().WithName("Country"); //Use ISO3116-1 alpha-3 codes
        }
    }
}
