using AutoMapper;
using MediatR;
using SchoolProject.Core.Basies;
using SchoolProject.Core.Features.Students.Query.Models;
using SchoolProject.Core.Features.Students.Query.Resopnse;
using SchoolProject.Core.Features.Students.Query.ResponseDTO;
using SchoolProject.Service.Abstracts;
//Mediator
namespace SchoolProject.Core.Features.Students.Query.Handler
{
    public class StudentQueryHandler(IStudentService studentService, IMapper mapper) : ResponseHandler, IRequestHandler<GetStudentListQuery, Basies.Response<List<GetStudentResponse>>>, IRequestHandler<GetStudentByIDQuery, Basies.Response<GetStudentResponseById>>
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
            var student = await _studentService.GetByIdAsync(request.Id);
            if (student == null)
            {
                return NotFound<GetStudentResponseById>();
            }
            var studentResponse = _mapper.Map<GetStudentResponseById>(student);
            return Success(studentResponse);
        }
    }
}
