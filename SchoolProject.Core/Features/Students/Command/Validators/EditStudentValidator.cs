using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Students.Command.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Command.Validators
{
    public class EditStudentValidator : AbstractValidator<EditStudentCommand>
    {
        private readonly IStudentService _studentService;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        public EditStudentValidator(IStudentService studentService, IStringLocalizer<SharedResources> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _studentService = studentService;
            ApplyEditValidationRule();
            ApplyCustomValidationsRule();
        }


        public void ApplyEditValidationRule()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .MaximumLength(50).WithMessage(_stringLocalizer[SharedResourcesKeys.ExceedingTheMaxLength])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Mustnotbenull]);

            //RuleFor(x => x.Address)
            //    .NotEmpty().WithMessage("Address is required")
            //    .MaximumLength(50).WithMessage("Max length is 50")
            //    .NotNull().WithMessage("Address Must not be null");
        }

        public void ApplyCustomValidationsRule()
        {
            RuleFor(x => x.Name)
                .MustAsync(async ( model,name, cancellation) => !await _studentService.IsNameExistExludeSelfAsync(name,model.Id))
                .WithMessage(_stringLocalizer[SharedResourcesKeys.IsExist]);
        }
    }
}
