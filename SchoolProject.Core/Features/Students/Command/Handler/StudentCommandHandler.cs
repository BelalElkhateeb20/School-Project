using AutoMapper;
using MediatR;
using SchoolProject.Core.Basies;
using SchoolProject.Core.Features.Students.Command.Models;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Command.Handler
{
    public class StudentCommandHandler(IMapper mapper, IStudentService studentService) : ResponseHandler, IRequestHandler<AddStudentCommand,Response<string>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IStudentService _studentService = studentService;


        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var studentmapping = _mapper.Map<Student>(request);
            var result = await _studentService.AddAsync(studentmapping);
            if (result == "Exists")
            {
                return UnprocessableEntity<string>("Student already exists");
            }
       
            else if (result == "success") 
            {
                return Created();
            }
            return BadRequest<string>();
        }
    }
}
