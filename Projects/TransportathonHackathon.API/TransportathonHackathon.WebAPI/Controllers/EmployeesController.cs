using Core.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using TransportathonHackathon.Application.Features.Employees.Queries.GetByCompanyId;

namespace TransportathonHackathon.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeesController : BaseController
    {
        [HttpGet("{CompanyId}")]
        public async Task<IActionResult> GetByCompanyId([FromRoute] GetByCompanyIdEmployeeQuery command)
        {
            IList<GetByCompanyIdEmployeeResponse> response = await Mediator.Send(command);
            return Ok(response);
        }
    }
}
