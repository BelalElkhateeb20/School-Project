
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Basies;
using SchoolProject.Core.Features.Users.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.infraStructure.Data;

namespace SchoolProject.Core.Features.Users.Commands.Handler
{
    public class UserCommandHandler(IStringLocalizer<SharedResources> stringLocalizer, IMapper mapper, UserManager<Data.Entities.Identity.User> userManager, ApplicationDBContext dBContext) : ResponseHandler(stringLocalizer), IRequestHandler<AddUserCommand, Response<string>>

    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer = stringLocalizer;
        private readonly IMapper _mapper = mapper;
        private readonly UserManager<Data.Entities.Identity.User> _userManager = userManager;
        private readonly ApplicationDBContext _dBContext = dBContext;

        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var tran = _dBContext.Database.BeginTransaction();
            try
            {
                // Check if the email already exists
                var Email = await _userManager.FindByEmailAsync(request.Email);
                if (Email != null) return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.EmailIsExist]);
                // Check if the username already exists
                var username = await _userManager.FindByNameAsync(request.UserName);

                if (username != null) return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.UserNameIsExist]);
                var UserMapping = _mapper.Map<Data.Entities.Identity.User>(request);   
                IdentityResult result = await _userManager.CreateAsync(UserMapping,request.Password);

                if (result.Succeeded)
                {
                    tran.Commit();
                    return Created<string>();
                }
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FaildToAddUser]); ;
            }
            catch
            {
                tran.Rollback();
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FaildToAddUser]); ;
            }
        }
    }
}
