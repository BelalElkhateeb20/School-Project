using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Basies;
using SchoolProject.Core.Features.Students.Command.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Command.Handler
{
    public class StudentCommandHandler(IMapper mapper, IStudentService studentService, IStringLocalizer<SharedResources> stringLocalizer) : ResponseHandler(stringLocalizer),
                IRequestHandler<AddStudentCommand, Response<string>>,
                IRequestHandler<EditStudentCommand, Response<string>>,
                IRequestHandler<DeleteStudentCommand, Response<string>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IStudentService _studentService = studentService;

        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var studentmapping = _mapper.Map<Student>(request);
            var result = await _studentService.AddAsync(studentmapping);
            if (result == "success")
            {
                return Created<string>();
            }
            return BadRequest<string>();
        } 
        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetByIdAsync(request.Id);
            if (student == null)
            {
                return NotFound<string>();
            }
            _mapper.Map(request, student);
            var result = await _studentService.EditAsync(student);

            if (result == "success")
            {
                return Updated<string>(); // Explicitly specify the type argument
            }
            else
            {
                return BadRequest<string>();
            }
        }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetByIdAsync(request.Id);
            if (student == null)
            {
                return NotFound<string>();
            }
            var result = await _studentService.DeleteAsync(student);

            if (result == "success")
            {
                return Deleted<string>();
            }
            else
            {
                return BadRequest<string>();
            }
        }
    }
}
