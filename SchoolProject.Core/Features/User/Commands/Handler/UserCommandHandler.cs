
using AutoMapper;
using Bogus.DataSets;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Basies;
using SchoolProject.Core.Features.User.Commands.Models;
using SchoolProject.Core.Features.User.Commands.Validator;
using SchoolProject.Core.Features.Users.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.infraStructure.Data;

namespace SchoolProject.Core.Features.Users.Commands.Handler
{
    public class UserCommandHandler(IStringLocalizer<SharedResources> stringLocalizer, IMapper mapper, UserManager<Data.Entities.Identity.User> userManager, ApplicationDBContext dBContext) : ResponseHandler(stringLocalizer)
        , IRequestHandler<AddUserCommand, Response<string>>
        , IRequestHandler< UpdateUserCommand, Response<string>>,
        IRequestHandler<DeleteUserCommand, Response<string>>,
        IRequestHandler<ChangeUserPasswardCommand, Response<string>>

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
                return BadRequest<string>(string.Join(", ", result.Errors.Select(x => x.Description)));
            }
            catch
            {
                tran.Rollback();
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FaildToAddUser]); ;
            }
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
