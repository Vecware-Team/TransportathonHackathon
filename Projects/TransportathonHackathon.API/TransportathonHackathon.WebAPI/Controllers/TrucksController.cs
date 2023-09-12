using Core.API.Controllers;
using Core.Persistence.Pagination;
using Microsoft.AspNetCore.Mvc;
using TransportathonHackathon.Application.Features.Trucks.Commands.Create;
using TransportathonHackathon.Application.Features.Trucks.Commands.Delete;
using TransportathonHackathon.Application.Features.Trucks.Commands.Update;
using TransportathonHackathon.Application.Features.Trucks.Queries.GetById;
using TransportathonHackathon.Application.Features.Trucks.Queries.GetList;

namespace TransportathonHackathon.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TrucksController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTruckCommand command)
        {
            CreatedTruckResponse response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteTruckCommand command)
        {
            DeletedTruckResponse response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTruckCommand command)
        {
            UpdatedTruckResponse response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("{VehicleId}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdTruckQuery command)
        {
            GetByIdTruckResponse response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetListTruckQuery command)
        {
            IPaginate<GetListTruckResponse> response = await Mediator.Send(command);
            return Ok(response);
        }
    }
}
