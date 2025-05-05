using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.API.Base;
using SchoolProject.Core.Features.Students.Command.Models;
using SchoolProject.Core.Features.Students.Query.Models;
using SchoolProject.Data.Router;

namespace SchoolProject.API.Controllers
{
    [ApiController]
    [Authorize]
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
        [Route(Router.Student.Paginate)]
        public async Task<IActionResult> Paginated([FromQuery] GetStudentPaginatedQuery studentPaginatedQuery)
        {
            var response = await Mediator.Send(studentPaginatedQuery);
            return Ok(response);
        }
        [HttpGet]
        [Route(Router.Student.GetById)]
        public async Task<IActionResult> GetByIdAsync( [FromRoute]int id)
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
        [HttpPut]
        [Route(Router.Student.Update)]
        public async Task<IActionResult> UpdateAsync( [FromForm] EditStudentCommand student)
        {
            var response = await Mediator.Send(student);
            return NewResult(response);
        }
        [HttpDelete]
        [Route(Router.Student.Delete)]
        public async Task<IActionResult> DeleteAsync([FromForm] int id)
        {
            var response = await Mediator.Send(new DeleteStudentCommand (id));
            return NewResult(response);
        }

    }
}
