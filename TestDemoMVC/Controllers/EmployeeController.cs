using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestDemoMVC.Models;
using TestDemoMVC.UseCases;

namespace TestDemoMVC.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAsync([FromBody] Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(new UpdateEmployeeCommand(employee));
            }

            return Ok(employee);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(new DeleteEmployeeCommand(id));
            }

            return Ok();
        }
    }
}
