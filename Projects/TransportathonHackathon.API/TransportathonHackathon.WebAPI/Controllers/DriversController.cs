using Core.API.Controllers;
using Core.Persistence.Pagination;
using Microsoft.AspNetCore.Mvc;
using TransportathonHackathon.Application.Features.Drivers.Commands.CreateDriver;
using TransportathonHackathon.Application.Features.Drivers.Commands.DeleteDriver;
using TransportathonHackathon.Application.Features.Drivers.Commands.UpdateDriver;
using TransportathonHackathon.Application.Features.Drivers.Queries.GetByCompanyId;
using TransportathonHackathon.Application.Features.Drivers.Queries.GetById;
using TransportathonHackathon.Application.Features.Drivers.Queries.GetList;
using TransportathonHackathon.WebAPI.Dtos.Driver;

namespace TransportathonHackathon.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DriversController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDriverDto command)
        {
            CreatedDriverResponse result = await Mediator.Send(Mapper.Map<CreateDriverCommand>(command));
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteDriverDto command)
        {
            DeletedDriverResponse result = await Mediator.Send(Mapper.Map<DeleteDriverCommand>(command));
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateDriverDto command)
        {
            UpdatedDriverResponse result = await Mediator.Send(Mapper.Map<UpdateDriverCommand>(command));
            return Ok(result);
        }

        [HttpGet("{EmployeeId}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdDriverQuery command)
        {
            GetByIdDriverResponse result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{CompanyId}")]
        public async Task<IActionResult> GetByCompanyId([FromRoute] GetByCompanyIdDriverQuery command)
        {
            IList<GetByCompanyIdDriverResponse> response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetListDriverQuery command)
        {
            Paginate<GetListDriverResponse> result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
