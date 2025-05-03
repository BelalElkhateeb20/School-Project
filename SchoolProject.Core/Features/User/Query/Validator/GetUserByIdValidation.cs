

using Bogus;
using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.User.Query.Models;
using SchoolProject.Core.Resources;
using System.Data;

namespace SchoolProject.Core.Features.User.Query.Validator
{
    public class GetUserByIdValidation:AbstractValidator<GetUserByIdQuery>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer; 


        public GetUserByIdValidation(IStringLocalizer<SharedResources> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            ApplyGetByIdvalidation();
            ApplyGetByIdCustomvalidation();

        }
        public void ApplyGetByIdvalidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Mustnotbenull]);
        }
        public void ApplyGetByIdCustomvalidation()
        {
        }
    }
}
