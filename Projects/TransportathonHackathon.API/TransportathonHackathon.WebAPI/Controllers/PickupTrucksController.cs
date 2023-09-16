using Core.API.Controllers;
using Core.Persistence.Pagination;
using Microsoft.AspNetCore.Mvc;
using TransportathonHackathon.Application.Features.PickupTrucks.Commands.Create;
using TransportathonHackathon.Application.Features.PickupTrucks.Commands.Delete;
using TransportathonHackathon.Application.Features.PickupTrucks.Commands.Update;
using TransportathonHackathon.Application.Features.PickupTrucks.Queries.GetById;
using TransportathonHackathon.Application.Features.PickupTrucks.Queries.GetList;
using TransportathonHackathon.WebAPI.Dtos.PickupTruck;

namespace TransportathonHackathon.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PickupTrucksController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePickupTruckDto command)
        {
            CreatedPickupTruckResponse response = await Mediator.Send(Mapper.Map<CreatePickupTruckCommand>(command));
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeletePickupTruckDto command)
        {
            DeletedPickupTruckResponse response = await Mediator.Send(Mapper.Map<DeletePickupTruckCommand>(command));
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePickupTruckDto command)
        {
            UpdatedPickupTruckResponse response = await Mediator.Send(Mapper.Map<UpdatePickupTruckCommand>(command));
            return Ok(response);
        }

        [HttpGet("{VehicleId}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdPickupTruckQuery command)
        {
            GetByIdPickupTruckResponse response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetListPickupTruckQuery command)
        {
            IPaginate<GetListPickupTruckResponse> response = await Mediator.Send(command);
            return Ok(response);
        }
    }
}
