using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Students.Command.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Command.Validators
{
    public class AddStudentValidation : AbstractValidator<AddStudentCommand>
    {
        private readonly IStudentService _studentService;
        private readonly IStringLocalizer<SharedResources> _localizer;

        public AddStudentValidation(IStudentService studentService, IStringLocalizer<SharedResources> localizer)
        {
            _studentService = studentService;
            _localizer = localizer;
            ApplyValidationsRule();
            ApplyCustomValidationsRule();

        }
        public void ApplyValidationsRule()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .MaximumLength(50).WithMessage(_localizer[SharedResourcesKeys.ExceedingTheMaxLength])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Mustnotbenull]);

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .MaximumLength(50).WithMessage(_localizer[SharedResourcesKeys.ExceedingTheMaxLength])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Mustnotbenull]);

            RuleFor(x => x.DepartmentID)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])

                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Mustnotbenull]);
        }
        public void ApplyCustomValidationsRule()
        {
            RuleFor(x => x.Name)
                .MustAsync(async (name, cancellation) => !await _studentService.IsNameExistAsync(name))
                .WithMessage(_localizer[SharedResourcesKeys.IsExist]);

            RuleFor(x => x.DepartmentID)
                .MustAsync(async (id, cancellation) => id.HasValue && await _studentService.DepartmebtNameISExistAsync(id.Value))
                .WithMessage(_localizer[SharedResourcesKeys.IsNotExist]);
        }
    }
}
