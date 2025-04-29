using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Basies;
using SchoolProject.Core.Features.Departments.Query.Models;
using SchoolProject.Core.Features.Departments.Query.ResponseDTO;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Departments.Query.Handler
{
    public class DepartmentHandler(IDepartmentService departmentService ,IMapper mapper, IStringLocalizer<SharedResources> stringLocalizer)  : ResponseHandler(stringLocalizer), IRequestHandler<GetDepartmentByIdQuery, Response<GetDepartmentByIdResponse>>
    {
        private readonly IDepartmentService _departmentService = departmentService;
        private readonly IMapper _mapper = mapper;
        private readonly IStringLocalizer _localizer = stringLocalizer;

        public async Task<Response<GetDepartmentByIdResponse>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var department = await _departmentService.GetByIdWitheIncludeAsync(request.Id);
            if (department==null)
            {
                return NotFound<GetDepartmentByIdResponse>();
            }
            var departmentMapping =_mapper.Map<GetDepartmentByIdResponse> (department);
            return Success(departmentMapping);
        }
    }
}
