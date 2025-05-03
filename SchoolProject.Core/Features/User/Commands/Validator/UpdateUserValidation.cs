using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.User.Commands.Models;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Features.User.Commands.Validator
{
    public class UpdateUserValidation : AbstractValidator<UpdateUserCommand>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        public UpdateUserValidation(IStringLocalizer<SharedResources> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            ApplyUpdateUserValidation();
        }
        public void ApplyUpdateUserValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Mustnotbenull]);
        }
    }
}
