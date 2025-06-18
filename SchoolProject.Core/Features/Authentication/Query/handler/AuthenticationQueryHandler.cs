using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Basies;
using SchoolProject.Core.Features.Authentication.Query.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authentication.Query.handler
{
    public class AuthenticationQueryHandler(IStringLocalizer<SharedResources> localizer, IAuthenticationService authenticationService) : ResponseHandler(localizer), IRequestHandler<ConfirmEmailQuery, Response<string>>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer = localizer;
        private readonly IAuthenticationService _authenticationService = authenticationService;

        public async Task<Response<string>> Handle(ConfirmEmailQuery request, CancellationToken cancellationToken)
        {
            //var confirmEmail = await _authenticationService.ConfirmEmail(request.Userid, request.Token);
            //if (confirmEmail == "Invalid email confirmation request")
            //    return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.ErrorWhenConfirmEmail]);
            //return Success<string>(_stringLocalizer[SharedResourcesKeys.ConfirmEmailDone]);

            var confirmEmail = await _authenticationService.ConfirmEmail(request.Userid, request.Token);
            return confirmEmail switch
            {
                "User not found" => BadRequest<string>(_stringLocalizer[SharedResourcesKeys.UserIsNotFound]),
                "InValid Token OR UserID " => BadRequest<string>(_stringLocalizer[SharedResourcesKeys.InvaildCode]),
                "Email confirmed successfully" => Success("", "", _stringLocalizer[SharedResourcesKeys.ConfirmEmailDone]),
                _ => BadRequest<string>(_stringLocalizer[SharedResourcesKeys.BadRequest]),
            };
        }
    }
}
