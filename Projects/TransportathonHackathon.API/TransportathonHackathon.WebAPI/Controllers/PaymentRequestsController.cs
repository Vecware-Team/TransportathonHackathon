using Core.API.Controllers;
using Core.Persistence.Pagination;
using Microsoft.AspNetCore.Mvc;
using TransportathonHackathon.Application.Features.PaymentRequests.Commands.Create;
using TransportathonHackathon.Application.Features.PaymentRequests.Commands.Delete;
using TransportathonHackathon.Application.Features.PaymentRequests.Commands.Pay;
using TransportathonHackathon.Application.Features.PaymentRequests.Commands.Update;
using TransportathonHackathon.Application.Features.PaymentRequests.Queries.GetByCompanyId;
using TransportathonHackathon.Application.Features.PaymentRequests.Queries.GetByCustomerId;
using TransportathonHackathon.Application.Features.PaymentRequests.Queries.GetById;
using TransportathonHackathon.Application.Features.PaymentRequests.Queries.GetList;
using TransportathonHackathon.WebAPI.Dtos.PaymentRequests;

namespace TransportathonHackathon.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PaymentRequestsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePaymentRequestDto command)
        {
            CreatedPaymentRequestResponse response = await Mediator.Send(Mapper.Map<CreatePaymentRequestCommand>(command));
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeletePaymentRequestDto command)
        {
            DeletedPaymentRequestResponse response = await Mediator.Send(Mapper.Map<DeletePaymentRequestCommand>(command));
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePaymentRequestDto command)
        {
            UpdatedPaymentRequestResponse response = await Mediator.Send(Mapper.Map<UpdatePaymentRequestCommand>(command));
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Pay([FromBody] PayPaymentRequestDto command)
        {
            PaidPaymentRequestResponse response = await Mediator.Send(Mapper.Map<PayPaymentRequestCommand>(command));
            return Ok(response);
        }

        [HttpGet("{TransportRequestId}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdPaymentRequestQuery command)
        {
            GetByIdPaymentRequestResponse response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("{CompanyId}")]
        public async Task<IActionResult> GetByCompanyId([FromRoute] GetByCompanyIdPaymentRequestQuery command)
        {
            IPaginate<GetByCompanyIdPaymentRequestResponse> response = await Mediator.Send(command);
            return Ok(response);
        }


        [HttpGet("{CustomerId}")]
        public async Task<IActionResult> GetByCustomerId([FromRoute] GetByCustomerIdPaymentRequestQuery command)
        {
            IPaginate<GetByCustomerIdPaymentRequestResponse> response = await Mediator.Send(command);
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
