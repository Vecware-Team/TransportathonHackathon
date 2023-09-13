using Core.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using TransportathonHackathon.Application.Features.Vehicles.Queries.GetByCompanyIdVehicle;

namespace TransportathonHackathon.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VehiclesController : BaseController
    {
        [HttpGet("{CompanyId}")]
        public async Task<IActionResult> GetByCompanyId([FromRoute] GetByCompanyIdVehicleQuery command)
        {
            IList<GetByCompanyIdVehicleResponse> response = await Mediator.Send(command);
            return Ok(response);
        }
    }
}
