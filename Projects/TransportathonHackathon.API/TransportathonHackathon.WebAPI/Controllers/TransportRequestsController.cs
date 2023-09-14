using Core.API.Controllers;
using Core.Persistence.Pagination;
using Microsoft.AspNetCore.Mvc;
using TransportathonHackathon.Application.Features.TransportRequests.Commands.Create;
using TransportathonHackathon.Application.Features.TransportRequests.Commands.Delete;
using TransportathonHackathon.Application.Features.TransportRequests.Commands.Update;
using TransportathonHackathon.Application.Features.TransportRequests.Queries.GetByCompanyId;
using TransportathonHackathon.Application.Features.TransportRequests.Queries.GetById;
using TransportathonHackathon.Application.Features.TransportRequests.Queries.GetList;

namespace TransportathonHackathon.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TransportRequestsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTransportRequestCommand command)
        {
            CreatedTransportRequestResponse response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteTransportRequestCommand command)
        {
            DeletedTransportRequestResponse response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTransportRequestCommand command)
        {
            UpdatedTransportRequestResponse response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdTransportRequestQuery command)
        {
            GetByIdTransportRequestResponse response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetListTransportRequestQuery command)
        {
            IPaginate<GetListTransportRequestResponse> response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetListByCompanyId([FromRoute] GetByCompanyIdTransportRequestQuery query)
        {
            IList<GetByCompanyIdTransportRequestResponse> response = await Mediator.Send(query);
            return Ok(response);
        }
    }
}
