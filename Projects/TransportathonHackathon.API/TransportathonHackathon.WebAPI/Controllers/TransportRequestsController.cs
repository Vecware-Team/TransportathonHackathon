using Core.API.Controllers;
using Core.Persistence.Pagination;
using Microsoft.AspNetCore.Mvc;
using TransportathonHackathon.Application.Features.TransportRequests.Commands.AddVehicle;
using TransportathonHackathon.Application.Features.TransportRequests.Commands.Approve;
using TransportathonHackathon.Application.Features.TransportRequests.Commands.ApproveAndPay;
using TransportathonHackathon.Application.Features.TransportRequests.Commands.Create;
using TransportathonHackathon.Application.Features.TransportRequests.Commands.Delete;
using TransportathonHackathon.Application.Features.TransportRequests.Commands.Finish;
using TransportathonHackathon.Application.Features.TransportRequests.Commands.Update;
using TransportathonHackathon.Application.Features.TransportRequests.Queries.GetByCompanyAndCustomer;
using TransportathonHackathon.Application.Features.TransportRequests.Queries.GetByCompanyId;
using TransportathonHackathon.Application.Features.TransportRequests.Queries.GetByCustomerId;
using TransportathonHackathon.Application.Features.TransportRequests.Queries.GetById;
using TransportathonHackathon.Application.Features.TransportRequests.Queries.GetList;
using TransportathonHackathon.WebAPI.Dtos.TransportRequest;

namespace TransportathonHackathon.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TransportRequestsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTransportRequestDto command)
        {
            CreatedTransportRequestResponse response = await Mediator.Send(Mapper.Map<CreateTransportRequestCommand>(command));
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteTransportRequestDto command)
        {
            DeletedTransportRequestResponse response = await Mediator.Send(Mapper.Map<DeleteTransportRequestCommand>(command));
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTransportRequestDto command)
        {
            UpdatedTransportRequestResponse response = await Mediator.Send(Mapper.Map<UpdateTransportRequestCommand>(command));
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Approve([FromBody] ApproveTransportRequestDto command)
        {
            ApproveTransportRequestResponse response = await Mediator.Send(Mapper.Map<ApproveTransportRequestCommand>(command));
            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> ApproveAndPay([FromBody] ApproveAndPayTransportRequestDto command)
        {
            ApproveAndPayTransportRequestResponse response = await Mediator.Send(Mapper.Map<ApproveAndPayTransportRequestCommand>(command));
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Finish([FromBody] FinishTransportRequestDto command)
        {
            FinishedTransportRequestResponse response = await Mediator.Send(Mapper.Map<FinishTransportRequestCommand>(command));
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddVehicleToTransportRequest([FromBody] AddVehicleTransportRequestDto command)
        {
            AddVehicleTransportRequestResponse response = await Mediator.Send(Mapper.Map<AddVehicleTransportRequestCommand>(command));
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

        [HttpGet("{CompanyId}")]
        public async Task<IActionResult> GetListByCompanyId([FromRoute] GetByCompanyIdTransportRequestQuery query)
        {
            IList<GetByCompanyIdTransportRequestResponse> response = await Mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("{CustomerId}")]
        public async Task<IActionResult> GetListByCustomerId([FromRoute] GetByCustomerIdTransportRequestQuery query)
        {
            IList<GetByCustomerIdTransportRequestResponse> response = await Mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("{CompanyId}/{CustomerId}")]
        public async Task<IActionResult> GetListByCompanyIdAndCustomerId([FromRoute] GetByCompanyAndCustomerTransportRequestQuery query)
        {
            IList<GetByCompanyAndCustomerTransportRequestResponse> response = await Mediator.Send(query);
            return Ok(response);
        }
    }
}
