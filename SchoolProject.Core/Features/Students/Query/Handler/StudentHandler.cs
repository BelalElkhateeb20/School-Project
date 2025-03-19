using AutoMapper;
using MediatR;
using SchoolProject.Core.Basies;
using SchoolProject.Core.Features.Students.Query.Models;
using SchoolProject.Core.Features.Students.Query.Resopnse;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Query.Handler
{
    class StudentHandler(IStudentService studentService , IMapper mapper) :ResponseHandler, IRequestHandler<GetStudentListQuery,Basies.Response<List<GetStudentResponse>>>
    {
        private readonly IStudentService _studentService = studentService;
        private readonly IMapper _mapper = mapper;

        public async Task<Basies.Response<List<GetStudentResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var studentList= await _studentService.GetStudentsAsync();
            var studemapp =  _mapper.Map<List<GetStudentResponse>>(studentList);
            return Success(studemapp);
        }

    }
}
