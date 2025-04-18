using AutoMapper;
using MediatR;
using SchoolProject.Core.Basies;
using SchoolProject.Core.Features.Students.Query.Models;
using SchoolProject.Core.Features.Students.Query.Resopnse;
using SchoolProject.Core.Features.Students.Query.ResponseDTO;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstracts;
using System.Linq.Expressions;
//Mediator
namespace SchoolProject.Core.Features.Students.Query.Handler
{
    public class StudentQueryHandler(IStudentService studentService, IMapper mapper) : ResponseHandler, 
        IRequestHandler<GetStudentListQuery,Basies.Response<List<GetStudentResponse>>>,
        IRequestHandler<GetStudentByIDQuery, Basies.Response<GetStudentResponseById>>,
        IRequestHandler<GetStudentPaginatedQuery, PaginatedResult<GetStudentPaginatedResponse>>
    {
        private readonly IStudentService _studentService = studentService;
        private readonly IMapper _mapper = mapper;

        public async Task<Basies.Response<List<GetStudentResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var studentLists = await _studentService.GetStudentsAsync();
            var studentmapp = _mapper.Map<List<GetStudentResponse>>(studentLists);
            return Success(studentmapp);
        }

        public async Task<Basies.Response<GetStudentResponseById>> Handle(GetStudentByIDQuery request, CancellationToken cancellationToken)
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
            Expression<Func<Student, GetStudentPaginatedResponse>> expression = e => new GetStudentPaginatedResponse(e.StudID,e.Name,e.Address,e.Department.DName);
            //var querable = _studentService.GetStudentsQuerable();
            var FilterQuery = _studentService.FilterQueryPaginate(request.Search);
            var paginatedList = FilterQuery.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);//select is for mapping 
            return paginatedList;

        }
    }
}
