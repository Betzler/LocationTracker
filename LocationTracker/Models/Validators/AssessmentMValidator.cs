using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using LocationTracker.Models.ViewModels;
namespace LocationTracker.Models.Validators
{
    public class AssessmentVMValidator : AbstractValidator<AssessmentViewModel>
    {
        public AssessmentVMValidator()
        {
            RuleFor(a => a.StartDate).NotEmpty().WithMessage("A start date must be entered.");
            RuleFor(a => a.EndDate).GreaterThanOrEqualTo(s => s.StartDate).WithMessage("End date must occur after the starting date.");
        }
    }
}
