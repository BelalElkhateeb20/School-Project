using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Basies;
using SchoolProject.Core.Features.Students.Query.Models;
using SchoolProject.Core.Features.Students.Query.Resopnse;
using SchoolProject.Core.Features.Students.Query.ResponseDTO;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstracts;
using System.Linq.Expressions;
//Mediator
namespace SchoolProject.Core.Features.Students.Query.Handler
{
    public class StudentQueryHandler(IStudentService studentService, IMapper mapper, IStringLocalizer<SharedResources> stringLocalizer) : ResponseHandler(stringLocalizer),
                IRequestHandler<GetStudentListQuery, Response<List<GetStudentResponse>>>,
                IRequestHandler<GetStudentByIDQuery, Response<GetStudentResponseById>>,
                IRequestHandler<GetStudentPaginatedQuery, PaginatedResult<GetStudentPaginatedResponse>>
    {
        private readonly IStudentService _studentService = studentService;
        private readonly IMapper _mapper = mapper;

        public async Task<Response<List<GetStudentResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var studentLists = await _studentService.GetStudentsAsync();
            var studentmapp = _mapper.Map<List<GetStudentResponse>>(studentLists);
            return Success(studentmapp);
        }

        public async Task<Response<GetStudentResponseById>> Handle(GetStudentByIDQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetByIdWitheIncludeAsync(request.Id);
            if (student == null)
            {
                return NotFound<GetStudentResponseById>();
            }
            var studentResponse = _mapper.Map<GetStudentResponseById>(student);
            return Found(studentResponse);
        }

        public Task<PaginatedResult<GetStudentPaginatedResponse>> Handle(GetStudentPaginatedQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Student, GetStudentPaginatedResponse>> expression = e => new GetStudentPaginatedResponse(e.StudID, e.NameEN, e.Address, e.Department.DNameEN);
            var FilterQuery = _studentService.FilterQueryPaginate(request.OrderBy, request.Search);
            var paginatedList = FilterQuery.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return paginatedList;
        }
    }
}
