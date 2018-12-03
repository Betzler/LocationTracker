using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using LocationTracker.Models.ViewModels;

namespace LocationTracker.Models.Validators
{
    public class LocationValidator : AbstractValidator<Location>
    {
        public LocationValidator()
        {
            /* Should look into changing the Fluent Validation rules for the POCOs and using Data Annotations for ViewModel validation */
            RuleFor(l => l.LocationCode).Length(3).NotEmpty().WithName("Location Code");

            
        }
    }
}
