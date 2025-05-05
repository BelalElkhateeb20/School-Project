
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Basies;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Authentication.Commands.Handler
{
    public class AuthenticationHandler(
        IStringLocalizer<SharedResources> localizer
        ,UserManager<Data.Entities.Identity.User> userManager,
        IAuthenticationService authenticationService
        ,SignInManager<Data.Entities.Identity.User> signInManager) : ResponseHandler(localizer)
        ,IRequestHandler<SignInCommand, Response<string>>
    {
        private readonly IStringLocalizer<SharedResources> _localizer = localizer;
        private readonly UserManager<Data.Entities.Identity.User> _userManager = userManager;
        private readonly IAuthenticationService _authenticationService = authenticationService;
        private readonly SignInManager<Data.Entities.Identity.User> _signInManager = signInManager;

        public async Task<Response<string>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null) return NotFound<string>(_localizer[SharedResourcesKeys.UserNameIsNotExist]);
            //signin
            var signin =  _signInManager.CheckPasswordSignInAsync(user,request.Passward,false);
            if (!signin.IsCompletedSuccessfully) return Faild<string>(_localizer[SharedResourcesKeys.UserNameOrPasswardIsWrong]);

            //Generate Token
            var jwttoken = await _authenticationService.GetTWTToken(user);
            return Success(jwttoken);
        }
    }
}
