using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.API.Base;
using SchoolProject.Core.Features.Departments.Query.Models;

namespace SchoolProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController() : AppController
    {

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var response = await Mediator.Send(new GetDepartmentByIdQuery(id));
            return NewResult(response);
        }   
    }
}
