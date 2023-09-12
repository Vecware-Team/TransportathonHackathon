using Core.API.Controllers;
using Core.Persistence.Pagination;
using Microsoft.AspNetCore.Mvc;
using TransportathonHackathon.Application.Features.Drivers.Commands.CreateDriver;
using TransportathonHackathon.Application.Features.Drivers.Commands.DeleteDriver;
using TransportathonHackathon.Application.Features.Drivers.Commands.UpdateDriver;
using TransportathonHackathon.Application.Features.Drivers.Queries.GetById;
using TransportathonHackathon.Application.Features.Drivers.Queries.GetList;

namespace TransportathonHackathon.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DriversController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDriverCommand command)
        {
            CreatedDriverResponse result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteDriverCommand command)
        {
            DeletedDriverResponse result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateDriverCommand command)
        {
            UpdatedDriverResponse result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{EmployeeId}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdDriverQuery command)
        {
            GetByIdDriverResponse result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetListDriverQuery command)
        {
            Paginate<GetListDriverResponse> result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
