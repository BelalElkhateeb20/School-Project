using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Basies;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Helpers;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Authentication.Commands.Handler
{
    public class AuthenticationCommandHandler(
        IStringLocalizer<SharedResources> localizer
        , UserManager<Data.Entities.Identity.User> userManager,
        IAuthenticationService authenticationService
        , SignInManager<Data.Entities.Identity.User> signInManager) : ResponseHandler(localizer)
        , IRequestHandler<SignInCommand, Response<JwtAuthRespone>>
        , IRequestHandler<RefreshTokenCommand, Response<JwtAuthRespone>>
        , IRequestHandler<ValidateTokenCommand, Response<TokenValidatedResult>>

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
            //if (await _userManager.IsLockedOutAsync(user))
            //    return Faild<JwtAuthRespone>(_localizer[SharedResourcesKeys.Youraccountislocked]);

            var signin = await _signInManager.CheckPasswordSignInAsync(user, request.Passward, true);
            if (!signin.Succeeded) return Faild<JwtAuthRespone>(_localizer[SharedResourcesKeys.UserNameOrPasswardIsWrong]);
            if (!user.EmailConfirmed) return Faild<JwtAuthRespone>(_localizer[SharedResourcesKeys.EmailNotConfirmed]);
            //Generate Token
            var jwttoken = await _authenticationService.GetJWTToken(user);
            return Success(jwttoken);
        }

        public async Task<Response<JwtAuthRespone>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var response = await _authenticationService.GetRefrechToken(request.AccessToken, request.RefreshToken);
            return Success(response);
        }
        public async Task<Response<TokenValidatedResult>> Handle(ValidateTokenCommand request, CancellationToken cancellationToken)
        {
            var result = _authenticationService.ValidateToken(request.AccessToken);
            var response = (result.IsValid, result.IsExpired) switch
            {
                (false, true) => Faild<TokenValidatedResult>(_localizer[SharedResourcesKeys.TokenIsExpired]),
                (true, false) => Success(result, _localizer[SharedResourcesKeys.TokenIsNotExpired]),
                (false, false) => Faild<TokenValidatedResult>(_localizer[SharedResourcesKeys.InvalidAndexpiredToken]),
                _ => Faild<TokenValidatedResult>(_localizer[_localizer[SharedResourcesKeys.BadRequest]])
            };
            return response;
        }

    }
}
