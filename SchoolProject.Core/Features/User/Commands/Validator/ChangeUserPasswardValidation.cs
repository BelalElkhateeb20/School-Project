using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.User.Commands.Models;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Features.User.Commands.Validator
{
    public class ChangeUserPasswardValidation:AbstractValidator<ChangeUserPasswardCommand>
    {
        private readonly IStringLocalizer<SharedResources> _localizer;
        public ChangeUserPasswardValidation(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;
            ApplyChangeUserPasswardValidation();
        }
        public void ApplyChangeUserPasswardValidation()
        {
            RuleFor(x=>x.OldPassward)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Mustnotbenull]);

            RuleFor(x=>x.NewPassward)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Mustnotbenull]);

            RuleFor(x => x.ConfirmPassward)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Mustnotbenull])
                .Matches(x => x.NewPassward).WithMessage(_localizer[SharedResourcesKeys.PasswordNotEqualConfirmPass]);
        }
    }
}
