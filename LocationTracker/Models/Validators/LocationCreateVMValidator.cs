
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
            RuleFor(vm => vm.LocationCode).Length(3).NotEmpty().WithName("Location Code");
            RuleFor(vm => vm.StateProvince).Length(2).WithName("State/Province");
            RuleFor(vm => vm.Country).Length(0, 3).NotEmpty().WithName("Country"); //Use ISO3116-1 alpha-3 codes
        }
    }
}
