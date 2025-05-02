using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Users.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Users.Commands.Validator
{
    public class AddUserValidation:AbstractValidator<AddUserCommand>
    {
        private readonly IStudentService _studentService;
        private readonly IStringLocalizer<SharedResources> _localizer;
        public AddUserValidation(IStudentService studentService, IStringLocalizer<SharedResources> localizer)
        {
            _studentService = studentService;
            _localizer = localizer;
            ApplyUserValidation();
            ApplyCustomUserValidationRule();

        }
        public void ApplyUserValidation()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .MaximumLength(50).WithMessage(_localizer[SharedResourcesKeys.ExceedingTheMaxLength])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Mustnotbenull]);

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .MaximumLength(50).WithMessage(_localizer[SharedResourcesKeys.ExceedingTheMaxLength])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Mustnotbenull]);

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])

                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Mustnotbenull]);

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])

                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Mustnotbenull]);

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .Matches(x => x.Password).WithMessage(_localizer[SharedResourcesKeys.PasswordNotEqualConfirmPass])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Mustnotbenull]);

        }
        public void ApplyCustomUserValidationRule()
        {
            
        }

    }
}
