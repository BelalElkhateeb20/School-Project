
using Microsoft.AspNetCore.Mvc;
using SchoolProject.API.Base;
using SchoolProject.Core.Features.Departments.Query.Models;
using SchoolProject.Data.Router;

namespace SchoolProject.API.Controllers
{
    [ApiController]
    public class DepartmentController : AppController
    {
        [HttpGet]
        [Route(Router.Department.GetById)]
        public async Task<IActionResult> GetDepartmentById([FromRoute]int id)
        {
            var response = await Mediator.Send(new GetDepartmentByIdQuery(id));
            return NewResult(response);
        }
    }
}
