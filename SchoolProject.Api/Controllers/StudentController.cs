using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers
{
    [ApiController]
    public class StudentController : ControllerBase
    {
        #region Fields

        private readonly IMediator _mediator;

        #endregion

        #region CTOR

        public StudentController(IMediator mediator) => _mediator = mediator;

        #endregion

        #region Routes

        [HttpGet(Router.StudentRouting.List)]
        public async Task<IActionResult> GetStudentList()
        {
            var response = await _mediator.Send(new GetStudentListQuery());

            return Ok(response);
        }

        [HttpGet(Router.StudentRouting.GetByID)]
        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetStudentByIdQuery(id));

            return Ok(response);
        }

        [HttpPost(Router.StudentRouting.Create)]
        public async Task<IActionResult> CreateStudent([FromBody] AddStudentCommand addStudentCommand)
        {
            var response = await _mediator.Send(addStudentCommand);

            return Ok(response);
        }

        #endregion

    }
}
