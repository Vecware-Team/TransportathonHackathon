using Core.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using TransportathonHackathon.Application.Features.TransportTypes.Commands.Create;
using TransportathonHackathon.Application.Features.TransportTypes.Commands.Delete;
using TransportathonHackathon.Application.Features.TransportTypes.Commands.Update;
using TransportathonHackathon.Application.Features.TransportTypes.Queries.GetById;
using TransportathonHackathon.Application.Features.TransportTypes.Queries.GetList;

namespace TransportathonHackathon.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TransportTypesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTransportTypeCommand command)
        {
            CreatedTransportTypeResponse response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteTransportTypeCommand command)
        {
            DeletedTransportTypeResponse response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTransportTypeCommand command)
        {
            UpdatedTransportTypeResponse response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdTransportTypeQuery command)
        {
            GetByIdTransportTypeResponse response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetListTransportTypeQuery command)
        {
            IList<GetListTransportTypeResponse> response = await Mediator.Send(command);
            return Ok(response);
        }
    }
}
