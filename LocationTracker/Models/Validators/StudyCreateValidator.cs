using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using LocationTracker.Models.ViewModels;

namespace LocationTracker.Models.Validators
{
    public class StudyCreateVMValidator : AbstractValidator<StudyCreateViewModel>
    {
        public StudyCreateVMValidator()
        {
            RuleFor(studyCreateVM => studyCreateVM.StudyName).MaximumLength(50).NotEmpty().WithName("Study Name");
            RuleFor(studyCreateVM => studyCreateVM.StudySize).InclusiveBetween(1, 15).NotEmpty().WithName("Study Size");
        }
    }
}
