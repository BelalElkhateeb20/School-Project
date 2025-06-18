using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Basies;
using SchoolProject.Core.Features.User.Commands.Models;
using SchoolProject.Core.Features.Users.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.infraStructure.Data;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Users.Commands.Handler
{
    public class UserCommandHandler(IStringLocalizer<SharedResources> stringLocalizer, IMapper mapper, UserManager<Data.Entities.Identity.User> userManager, ApplicationDBContext dBContext ,IApplicationUserService applicationUser) : ResponseHandler(stringLocalizer)
        , IRequestHandler<AddUserCommand, Response<string>>
        , IRequestHandler< UpdateUserCommand, Response<string>>,
        IRequestHandler<DeleteUserCommand, Response<string>>,
        IRequestHandler<ChangeUserPasswardCommand, Response<string>>

    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer = stringLocalizer;
        private readonly IMapper _mapper = mapper;
        private readonly UserManager<Data.Entities.Identity.User> _userManager = userManager;
        private readonly ApplicationDBContext _dBContext = dBContext;
        private readonly IApplicationUserService _applicationUser = applicationUser;

        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var usermapping = _mapper.Map<Data.Entities.Identity.User>(request);
            var response = await _applicationUser.AddAsyenc(usermapping, request.Password, request.Role,request.DeparmentID);

           if ( response == "User Created Successfully") return Created<string>();

           if ( response == "This Role in Not Found") return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.RoleNotExist]);
            
            return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FaildToAddUser]); 
        }

        public async Task<Response<string>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var trans = await _dBContext.Database.BeginTransactionAsync();
            try
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id.Equals(request.Id));
                if (user ==null) return NotFound<string>();
              
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    trans.Commit();
                    var usermapping = _mapper.Map(request,user);
                    return Updated<string>(_stringLocalizer[SharedResourcesKeys.Updated]);
                }
                return Faild<string>(_stringLocalizer[SharedResourcesKeys.UpdateFailed]);
            }
            catch
            {
                trans.Rollback();
                return Faild<string>(_stringLocalizer[SharedResourcesKeys.UpdateFailed]);
            }
        }

        public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var trans = await _dBContext.Database.BeginTransactionAsync();
            try
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id.Equals(request.Id));
                if (user == null) return NotFound<string>();

                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    trans.Commit();
                    return Deleted <string>(_stringLocalizer[SharedResourcesKeys.Deleted]);
                }
                return Faild<string>(_stringLocalizer[SharedResourcesKeys.DeletedFailed]);
            }
            catch
            {
                trans.Rollback();
                return Faild<string>(_stringLocalizer[SharedResourcesKeys.DeletedFailed]);
            }
        }

        public async Task<Response<string>> Handle(ChangeUserPasswardCommand request, CancellationToken cancellationToken)
        {
            var trans = await _dBContext.Database.BeginTransactionAsync();
            try
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id.Equals(request.Id));
                if (user == null) return NotFound<string>();

                var passwordHasher = new PasswordHasher<Data.Entities.Identity.User>();
                var passresult = passwordHasher.VerifyHashedPassword(user, user.PasswordHash!, request.OldPassward);

                if (passresult.Equals( request.OldPassward)) return Faild<string>(_stringLocalizer[SharedResourcesKeys.PasswordNotCorrect]);

                var result = await _userManager.ChangePasswordAsync(user,request.OldPassward, request.NewPassward);
                if (result.Succeeded)
                {
                    trans.Commit();
                    return Success<string>(_stringLocalizer[SharedResourcesKeys.PasswordChangedSuccessfully]);
                }
                return Faild<string>(_stringLocalizer[SharedResourcesKeys.ChangePassFailed]);
            }
            catch
            {
                trans.Rollback();
                return Faild<string>(_stringLocalizer[SharedResourcesKeys.ChangePassFailed]);
            }

        }
    }
}
