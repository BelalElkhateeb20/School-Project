
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Tokens;
using SchoolProject.Core.Basies;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Helpers;
using SchoolProject.Service.Abstracts;
using System.Text;

namespace SchoolProject.Core.Features.Authentication.Commands.Handler
{
    public class AuthenticationHandler(
        IStringLocalizer<SharedResources> localizer
        ,UserManager<Data.Entities.Identity.User> userManager,
        IAuthenticationService authenticationService
        ,SignInManager<Data.Entities.Identity.User> signInManager) : ResponseHandler(localizer)
        ,IRequestHandler<SignInCommand, Response<JwtAuthRespone>>
        ,IRequestHandler<RefreshTokenCommand, Response<JwtAuthRespone>>
        ,IRequestHandler<ValidateTokenCommand, Response<TokenValidatedResult>>
        
    {
        private readonly IStringLocalizer<SharedResources> _localizer = localizer;
        private readonly UserManager<Data.Entities.Identity.User> _userManager = userManager;
        private readonly IAuthenticationService _authenticationService = authenticationService;
        private readonly SignInManager<Data.Entities.Identity.User> _signInManager = signInManager;

        public async Task<Response<JwtAuthRespone>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null) return NotFound<JwtAuthRespone>(_localizer[SharedResourcesKeys.UserNameIsNotExist]);
            //signin
            var signin =  _signInManager.CheckPasswordSignInAsync(user,request.Passward,false);
            if (!signin.IsCompletedSuccessfully) return Faild<JwtAuthRespone>(_localizer[SharedResourcesKeys.UserNameOrPasswardIsWrong]);

            //Generate Token
            var jwttoken =  await _authenticationService.GetJWTToken(user);
            return Success(jwttoken);
        }

        public async Task<Response<JwtAuthRespone>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var response = await _authenticationService.GetRefrechToken(request.AccessToken, request.RefreshToken);
            return Success(response);
        }

        public async Task<Response<TokenValidatedResult>> Handle(ValidateTokenCommand request, CancellationToken cancellationToken)
        {
            var response = _authenticationService.ValidateToken(request.AccessToken);
            return Success(response);
        }
    }
}
