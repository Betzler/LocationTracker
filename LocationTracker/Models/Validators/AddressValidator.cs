using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using LocationTracker.Models.ViewModels;

namespace LocationTracker.Models.Validators
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            /* Should look into changing the Fluent Validation rules for the POCOs and using Data Annotations for ViewModel validation */

            RuleFor(a => a.StateProvince).Length(2).WithName("State/Province");
            RuleFor(a => a.Country).Length(3).NotEmpty().WithName("Country"); //Use ISO3116-1 alpha-3 codes

        }
    }
}
