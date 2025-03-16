using MediatR;
using SchoolProject.Core.Features.Students.Query.Models;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Query.Handler
{
    class StudentHandler(IStudentService studentService) : IRequestHandler<GetStudentListQuery,List<Student>>
    {
        private readonly IStudentService _studentService = studentService;

        public async Task<List<Student>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            return await _studentService.GetStudentsAsync();
        }
    }
}
