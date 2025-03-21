using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Features.Students.Query.Models;
using SchoolProject.Data.Entities;

namespace SchoolProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _mediator.Send(new GetStudentListQuery());
            return Ok(response);
        }
        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetByIdAsync( int id)
        {
            var response = await _mediator.Send(new GetStudentByIDQuery(id));
            return Ok(response);
        }

    }
}
