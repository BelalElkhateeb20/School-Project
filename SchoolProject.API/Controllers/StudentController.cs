using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Features.Students.Command.Models;
using SchoolProject.Core.Features.Students.Query.Models;
using SchoolProject.Data.Entities;
using SchoolProject.Data.Router;

namespace SchoolProject.API.Controllers
{
    [ApiController]
    public class StudentController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        [Route(Router.Student.GetAll)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _mediator.Send(new GetStudentListQuery());
            return Ok(response);
        }
        [HttpGet]
        [Route(Router.Student.GetById)]
        public async Task<IActionResult> GetByIdAsync( int id)
        {
            var response = await _mediator.Send(new GetStudentByIDQuery(id));
            return Ok(response);
        }
                
        [HttpPost]
        [Route(Router.Student.perfix)]
        public async Task<IActionResult> AddAsync([FromForm] AddStudentCommand student)
        {
            var response= await _mediator.Send(student);
            return Ok(response);
        }

    }
}
