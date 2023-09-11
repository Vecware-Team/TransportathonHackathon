using Core.API.Controllers;
using Core.Persistence.Pagination;
using Microsoft.AspNetCore.Mvc;
using TransportathonHackathon.Application.Features.Carriers.Commands.Create;
using TransportathonHackathon.Application.Features.Carriers.Commands.Delete;
using TransportathonHackathon.Application.Features.Carriers.Commands.Update;
using TransportathonHackathon.Application.Features.Carriers.Queries.GetById;
using TransportathonHackathon.Application.Features.Carriers.Queries.GetList;

namespace TransportathonHackathon.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarriersController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateCarrier([FromBody] CreateCarrierCommand command)
        {
            CreatedCarrierResponse response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCarrier([FromQuery] DeleteCarrierCommand command)
        {
            DeletedCarrierResponse response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCarrier([FromBody] UpdateCarrierCommand command)
        {
            UpdatedCarrierResponse response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("{EmployeeId}")]
        public async Task<IActionResult> GetByIdCarrier([FromRoute] GetByIdCarrierQuery command)
        {
            GetByIdCarrierResponse response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetListCarrier([FromQuery] GetListCarrierQuery command)
        {
            IPaginate<GetListCarrierResponse> response = await Mediator.Send(command);
            return Ok(response);
        }
    }
}
