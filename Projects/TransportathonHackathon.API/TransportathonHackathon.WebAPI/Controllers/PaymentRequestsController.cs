using Core.API.Controllers;
using Core.Persistence.Pagination;
using Microsoft.AspNetCore.Mvc;
using TransportathonHackathon.Application.Features.PaymentRequests.Commands.Create;
using TransportathonHackathon.Application.Features.PaymentRequests.Commands.Delete;
using TransportathonHackathon.Application.Features.PaymentRequests.Commands.Update;
using TransportathonHackathon.Application.Features.PaymentRequests.Queries.GetById;
using TransportathonHackathon.Application.Features.PaymentRequests.Queries.GetList;

namespace TransportathonHackathon.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PaymentRequestsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePaymentRequestCommand command)
        {
            CreatedPaymentRequestResponse response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeletePaymentRequestCommand command)
        {
            DeletedPaymentRequestResponse response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePaymentRequestCommand command)
        {
            UpdatedPaymentRequestResponse response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("{TransportRequestId}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdPaymentRequestQuery command)
        {
            GetByIdPaymentRequestResponse response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetListPaymentRequestQuery command)
        {
            IPaginate<GetListPaymentRequestResponse> response = await Mediator.Send(command);
            return Ok(response);
        }
    }
}
