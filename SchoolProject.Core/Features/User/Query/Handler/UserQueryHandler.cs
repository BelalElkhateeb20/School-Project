using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Basies;
using SchoolProject.Core.Features.User.Query.Models;
using SchoolProject.Core.Features.User.Query.ResponseDTO;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Wrappers;


namespace SchoolProject.Core.Features.User.Query.Handler
{
    public class UserQueryHandler (IStringLocalizer<SharedResources> stringLocalizer ,UserManager<Data.Entities.Identity.User> userManager ,IMapper mapper):ResponseHandler(stringLocalizer)
        , IRequestHandler<GetUserPagination, PaginatedResult<GetUserpaginatedResponse>>
        ,IRequestHandler<GetUserByIdQuery, Response<GetUserByIdResponse>>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer = stringLocalizer;
        private readonly UserManager<Data.Entities.Identity.User> _userManager = userManager;
        private readonly IMapper _mapper = mapper;

        public async Task<PaginatedResult<GetUserpaginatedResponse>> Handle(GetUserPagination request, CancellationToken cancellationToken)
        {
            var User = _userManager.Users.AsQueryable();
            //Expression<Func<Data.Entities.Identity.User, GetUserpaginatedResponse>> expression = e => new GetUserpaginatedResponse(e.FullName,e.Email,e.Address,e.PhoneNumber);
            var usermapping = _mapper.ProjectTo<GetUserpaginatedResponse>(User);
            var paginatedList = await usermapping.ToPaginatedListAsync( request.pageNumber, request.pageSize);
            return paginatedList;
        }

        public async Task<Response<GetUserByIdResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(request.Id));
            if (user==null)
            {
                return NotFound<GetUserByIdResponse>();
            }
            var usermapping = _mapper.Map<GetUserByIdResponse>(user);
            return Success<GetUserByIdResponse> (usermapping);
        }
    }
}
