using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.API.Base;
using SchoolProject.Core.Features.Students.Command.Models;
using SchoolProject.Core.Features.Students.Query.Models;
using SchoolProject.Data.Entities;
using SchoolProject.Data.Router;

namespace SchoolProject.API.Controllers
{
    [ApiController]
    public class StudentController: AppController
    {

        [HttpGet]
        [Route(Router.Student.GetAll)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await Mediator.Send(new GetStudentListQuery());
            return NewResult(response);
        }
        [HttpGet]
        [Route(Router.Student.GetById)]
        public async Task<IActionResult> GetByIdAsync( int id)
        {
            var response = await Mediator.Send(new GetStudentByIDQuery(id));
            return NewResult(response);
        }
                
        [HttpPost]
        [Route(Router.Student.perfix)]
        public async Task<IActionResult> AddAsync([FromBody] AddStudentCommand student)
        {
            var response= await Mediator.Send(student);
            return NewResult(response);
        }

    }
}
