using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Authorization.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Authorization.Commands.Validator
{
    public class AddRoleValidation : AbstractValidator<AddRoleCommand>
    {
        private readonly IAuthorizationService _authorizationservice;
        private readonly IStringLocalizer<SharedResources> _localizer;
        public AddRoleValidation(IAuthorizationService authorization , IStringLocalizer<SharedResources> localizer)
        {
            _authorizationservice = authorization;
            _localizer = localizer;
            ApplyValidationsRule();
            ApplyCustomValidationsRule();

        }
        public void ApplyValidationsRule()
        {
            RuleFor(x => x.RoleName)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .MaximumLength(50).WithMessage(_localizer[SharedResourcesKeys.ExceedingTheMaxLength])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Mustnotbenull]);


        }
        public void ApplyCustomValidationsRule()
        {
            RuleFor(x => x.RoleName)
                .MustAsync(async (key, cancellation) =>  !await _authorizationservice.IsRoleExistsAsync(key))
                .WithMessage(_localizer[SharedResourcesKeys.RoleIsExist]);
        }
    }
}
