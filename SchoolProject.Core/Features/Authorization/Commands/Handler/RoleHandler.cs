using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Basies;
using SchoolProject.Core.Features.Authorization.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Enums;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Authorization.Commands.Handler
{
    public class RoleHandler(IStringLocalizer<SharedResources> stringLocalizer , IAuthorizationService service , IMapper mapper, RoleManager<Role> roleManager) : ResponseHandler(stringLocalizer),IRequestHandler<AddRoleCommand, Response<string>>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer = stringLocalizer;
        private readonly IAuthorizationService _service = service;
        private readonly IMapper _mapper = mapper;
        private readonly RoleManager<Role> _roleManager = roleManager;


        public async Task<Response<string>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var rolemapping = _mapper.Map<Role>(request);
            var respo = _service.AddRoleAsync(rolemapping).Result;
            if (respo == ResultStatus.AlreadyExists)  return Faild<string>(_stringLocalizer[SharedResourcesKeys.RoleIsExist]);
            return Created<string>(_stringLocalizer[SharedResourcesKeys.Created]);
        }
    }
}
